    using System;
    using System.Windows.Forms;
    
    namespace StackOverflow_2013_05_19_Form1_Form2_buttons
    {
        public partial class Form2 : Form
        {
            public Form2()
            { InitializeComponent(); }
    
            private void button1_Click(object sender, EventArgs e)
            { Program.button.Enabled = true; }
        }
    }
