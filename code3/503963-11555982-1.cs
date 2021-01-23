    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace BarCode
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public bool[] barCodeBits;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Random r = new Random();
                int numberOfBits = 100;
                barCodeBits = new bool[numberOfBits];
                for(int i = 0; i < numberOfBits; i++) {
                    barCodeBits[i] = (r.Next(0, 2) == 1) ? true : false;
                }
    
                Form1_Resize(null, null);
            }
    
            private void Form1_Resize(object sender, EventArgs e)
            {
                int w = pictureBox1.Width;
                int h = pictureBox1.Height;
    
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                Brush b = new SolidBrush(Color.Black);
    
                for(int pos = 0; pos < barCodeBits.Length; pos++) {
                    if(barCodeBits[pos]) {
                        g.FillRectangle(b, ((float)pos / (float)barCodeBits.Length) * w, 0, (1.0f / (float)barCodeBits.Length) * w, h);
                    }
                }
            }
        }
    }
