    using System;
    using System.Windows.Forms;
    
    namespace TestForm
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                
                //This is important. Set one of them to be Visible and the other one to be invisible
                grpMeter.Visible = false;
                grpTags.Visible = true;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                grpMeter.Visible = !grpMeter.Visible;
                grpTags.Visible = !grpTags.Visible;
            }
        }
    }
