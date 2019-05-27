using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic;

namespace Timer
{
    public partial class Form1 : Form
    {
        int CountOrgNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCount_Click(object sender, EventArgs e)
        {
            ProcessTimer();
        }

        private void ProcessTimer()
        {
            if (IntCheck())
            {
                this.CountOrgNum = Convert.ToInt32(this.txtNum.Text);
                this.txtNum.ReadOnly = true;
                this.Timer.Enabled = true;
            }
            else
            {
                this.txtNum.Focus();
                this.txtNum.Text = "";
            }
        }

        private bool IntCheck()
        {
            if (Information.IsNumeric(this.txtNum.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("숫자만 입력해 주세요", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(this.CountOrgNum < 1)
            {
                this.Timer.Enabled = false;
                MessageBox.Show("펑!", "알림",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                this.txtNum.ReadOnly = false;
                this.txtNum.Text = "";
                this.txtNum.Focus();
            }
            else
            {
                this.CountOrgNum = this.CountOrgNum - 1;
                this.txtCountDown.Text = 
                    Convert.ToString(this.CountOrgNum);
            }
        }

        private void TxtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                ProcessTimer();
            }
        }
    }
}
