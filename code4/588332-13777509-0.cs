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
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
    
                for (int x = 0, y = 0; x + y != (this.Width + this.Height); x++)
                {
                    var color = Color.Red;
                    if (x % 2 == 0 && y % 2 != 0) { color = Color.Blue; }
    
                    e.Graphics.FillRectangle(new SolidBrush(color), x, y, 1, 1);
    
                    if (x == this.Width)
                    {
                        x = -1;
                        y++;
                    }
                }
            }
        }
    }
