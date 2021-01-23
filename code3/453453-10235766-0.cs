    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WinFormsSandbox
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void chkDisable_CheckedChanged(object sender, EventArgs e)
            {
                SetControlsEnabledStatus(!((CheckBox)sender).Checked);
            }
    
            private void SetControlsEnabledStatus(bool enabledStatus)
            {
                textBox1.Enabled = enabledStatus;
                textBox2.Enabled = enabledStatus;
            }
        }
    }
