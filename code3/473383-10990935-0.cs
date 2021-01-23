    using System;
    using System.Windows.Forms;
    
    namespace test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                //Form Closing Event
                e.Cancel = true;
                Hide();
            }
    
            private void toolStripMenuItem1_Click(object sender, EventArgs e)
            {
                //Exit in notify icon Context menu tool strip
               Environment.Exit(-1);
            }
    
            private void toolStripMenuItem2_Click(object sender, EventArgs e)
            {
                //Show in notify icon context menu tool strip
                Show();
            }
        }
    }
