    using System;
    using System.Windows.Forms;
    
    namespace StackOverflow_2013_05_19_Form1_Form2_buttons
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                button2.Enabled = false;
    
                Program.button = button2;
            }
    
            private void button1_Click(object sender, EventArgs e)
            { new Form2().Show(); }
    
            private void button2_Click(object sender, EventArgs e) { }
        }
    }
