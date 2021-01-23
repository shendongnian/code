    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace ImageChanger
    {
        public partial class Form1 : Form
        {
            PictureBox[] pictureBoxs=new PictureBox[4];
     
            public Form1()
            {
                InitializeComponent();
    
    
                pictureBoxs[0] = pictureBox1;
                pictureBoxs[1] = pictureBox2;
                pictureBoxs[2] = pictureBox3;
                pictureBoxs[3] = pictureBox4;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < 4; i++)
                {
                    // Load Image from Resources
                    pictureBoxs[i].Image = Properties.Resources.img100;
                    Application.DoEvents();
                    Thread.Sleep(1000);
                }
            }
    
    
        }
    }
