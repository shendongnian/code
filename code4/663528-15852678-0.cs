    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public Random r = new Random();
            private void timer1_Tick(object sender, EventArgs e)
            {
                int x = r.Next(0,925);
                int y = r.Next(0,445);
                pictureBox1.Top = y;
                pictureBox1.Left = x;
            }
        }
    }
