    using System;
    using System.Windows.Forms;
    namespace ReusingUserControlsSample
    {
        public partial class MyUserControlWithButtons : UserControl
        {
            public MyUserControlWithButtons()
            {
                InitializeComponent();
            }
            public TextBox TheOutput { get; set; }
            private void btnLetterA_Click(object sender, EventArgs e)
            {
                TheOutput.Text += "A";
            }
            private void btnLetterB_Click(object sender, EventArgs e)
            {
                TheOutput.Text += "B";
            }
            private void btnLetterC_Click(object sender, EventArgs e)
            {
                TheOutput.Text += "C";
            }
        }
    }
