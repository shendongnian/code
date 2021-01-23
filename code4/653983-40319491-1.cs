    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    
    // add WindowsBase and PresentationCore assemblies
    
    namespace ReportPrepare
    {
        public partial class Form1 : Form
        {
            PictureBox picbox = new PictureBox();
            int i = 0;
            Timer t = new Timer();
    
            public Form1()
            {
                InitializeComponent();
    
                
                this.Controls.Add(picbox);
                picbox.Dock = DockStyle.Fill;
    
                t.Interval = 5000;
                t.Tick += t_Tick;
                t.Enabled = true;
    
                this.Shown += Form1_Shown;
                this.SizeChanged += Form1_SizeChanged;
    
                this.Size = new Size(812, 400);
    
                this.StartPosition = FormStartPosition.CenterScreen;
    
            }
    
            void Form1_Shown(object sender, EventArgs e)
            {
                DrawText();
            }
    
            void t_Tick(object sender, EventArgs e)
            {
                i++;
                if (i > 3)
                {
                    i = 0;
                }
                DrawText();
            }
       
    
            private void DrawText()
            {
    
                // text and font
                string text = "one two three four five six seven eight nine ten eleven twelve";
    
                Font font = new System.Drawing.Font("Arial", 30, FontStyle.Regular, GraphicsUnit.Point);
    
                switch (i)
                {
                    case 0:
                        picbox.Image = TextDrawing.DrawTextToBitmap(text, font, Color.Red, TextDrawing.DrawMethod.AutosizeAccordingToText, new RectangleF(0, 0, picbox.Width, picbox.Height));
                        break;
                    case 1:
                        picbox.Image = TextDrawing.DrawTextToBitmap(text, font, Color.Red, TextDrawing.DrawMethod.AutoFitInConstantRectangleWithoutWarp, new RectangleF(0, 0, picbox.Width, picbox.Height));
                        break;
                    case 2:
                        picbox.Image = TextDrawing.DrawTextToBitmap(text, font, Color.Red, TextDrawing.DrawMethod.AutoWarpInConstantRectangle, new RectangleF(0, 0, picbox.Width, picbox.Height));
                        break;
                    case 3:
                        picbox.Image = TextDrawing.DrawTextToBitmap(text, font, Color.Red, TextDrawing.DrawMethod.AutoFitInConstantRectangleWithWarp, new RectangleF(0, 0, picbox.Width, picbox.Height));
                        break;
                }
                this.Text = ((TextDrawing.DrawMethod)(i)).ToString() + "                      Please resize window size by mouse to see drawing methods differences";
                
            }
    
            private void Form1_SizeChanged(object sender, EventArgs e)
            {
                t.Enabled = false;
                t.Enabled = true;
                DrawText();
            }
    
    
    
    
    
        }
    }
    
