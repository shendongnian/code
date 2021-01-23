    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Diagnostics;
    
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Load += Form1_Load;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Random rnd = new Random();
                Chart mych = new Chart();
                mych.Height = 100;
                mych.Width = 100;
                mych.BackColor = SystemColors.Highlight;
                mych.Series.Add("duck");
    
                mych.Series["duck"].SetDefault(true);
                mych.Series["duck"].Enabled = true;
                mych.Visible = true;
    
                for (int q = 0; q < 10; q++)
                {
                    int first = rnd.Next(0, 10);
                    int second = rnd.Next(0, 10);
                    mych.Series["duck"].Points.AddXY(first, second);
                    Debug.WriteLine(first + "  " + second);
                }
                
                Controls.Add(mych);
            }
        }
    }
