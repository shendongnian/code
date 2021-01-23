    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace countdowntimer
    {
        public partial class Form1 : Form
        {
            private Timer timeX;
            private int minutesLeft;
            
            public Form1()
            {
                InitializeComponent();
                
                timeX = new Timer(){Interval = 60000};
                timeX.Tick += new EventHandler(timeX_Tick);
            }
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
            }
            private void button1_Click(object sender, EventArgs e)
            {
                minutesLeft=30;
                timeX.Start();
            }
            void timeX_Tick(object sender, EventArgs e)
            {
                if(minutesLeft--<=0)
                {
                  timeX.Stop();
                  // Done!
                }
                else
                {
                  // Not done yet...
                }
                textBox1.Text = minutesLeft + " mins remaining";
            }
        }
    }
