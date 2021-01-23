    using System;  
    using System.Collections.Generic;  
    using System.Text;  
    using System.Drawing;  
    using System.Data;  
    using System.Windows.Forms;  
    namespace ButtonZ  
    {  
        public class ButtonZ : System.Windows.Forms.Button  
        {  
            Color clr1, clr2;  
            private Color color1 = Color.LightGreen;  
            private Color color2 = Color.DarkBlue;  
            private Color m_hovercolor1 = Color.Yellow;  
            private Color m_hovercolor2 = Color.DarkOrange;  
            private int color1Transparent = 150;  
            private int color2Transparent = 150;  
            private Color clickcolor1 = Color.DarkOrange;  
            private Color clickcolor2 = Color.Red;  
            private int angle = 90;  
            private int textX = 100;  
            private int textY = 25;  
            private String text = "";  
      
            //Create Properties to read Button Text,Colors etc  
            public String DisplayText  
            {  
                get { return text; }  
                set { text = value; Invalidate(); }  
            }  
      
            public Color StartColor  
            {  
                get { return color1; }  
                set { color1 = value; Invalidate(); }  
            }  
      
            public Color EndColor  
            {  
                get { return color2; }  
                set { color2 = value; Invalidate(); }  
            }  
      
            public Color MouseHoverColor1  
            {  
                get { return m_hovercolor1; }  
                set { m_hovercolor1 = value; Invalidate(); }  
            }  
      
            public Color MouseHoverColor2  
            {  
                get { return m_hovercolor2; }  
                set { m_hovercolor2 = value; Invalidate(); }  
            }  
      
            public Color MouseClickColor1  
            {  
                get { return clickcolor1; }  
                set { clickcolor1 = value; Invalidate(); }  
            }  
      
            public Color MouseClickColor2  
            {  
                get { return clickcolor2; }  
                set { clickcolor2 = value; Invalidate(); }  
            }  
      
            public int Transparent1  
            {  
                get { return color1Transparent; }  
                set  
                {  
                    color1Transparent = value;  
                    if (color1Transparent > 255)  
                    {  
                        color1Transparent = 255;  
                        Invalidate();  
                    }  
                    else  
                        Invalidate();  
                }  
            }  
      
            public int Transparent2  
            {  
                get { return color2Transparent; }  
                set  
                {  
                    color2Transparent = value;  
                    if (color2Transparent > 255)  
                    {  
                        color2Transparent = 255;  
                        Invalidate();  
                    }  
                    else  
                        Invalidate();  
                }  
            }  
      
            public int GradientAngle  
            {  
                get { return angle; }  
                set { angle = value; Invalidate(); }  
            }  
      
            public int TextLocation_X  
            {  
                get { return textX; }  
                set { textX = value; Invalidate(); }  
            }  
      
            public int TextLocation_Y  
            {  
                get { return textY; }  
                set { textY = value; Invalidate(); }  
            }  
      
            public ButtonZ()  
            {  
                this.Size = new System.Drawing.Size(200, 50);  
                this.ForeColor = Color.White;  
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;  
                text = this.Text;  
            }  
      
            //method mouse enter  
            protected override void OnMouseEnter(EventArgs e)  
            {  
                base.OnMouseEnter(e);  
                clr1 = color1;  
                clr2 = color2;  
                color1 = m_hovercolor1;  
                color2 = m_hovercolor2;  
            }  
      
            //method mouse leave  
            protected override void OnMouseLeave(EventArgs e)  
            {  
                base.OnMouseLeave(e);  
                color1 = clr1;  
                color2 = clr2;  
            }  
      
            //method mouse click  
            protected override void OnMouseClick(MouseEventArgs e)  
            {  
                if (e.Clicks == 1)  
                {  
                    base.OnMouseClick(e);  
                    color1 = clickcolor1;  
                    color2 = clickcolor2;  
                }  
            }  
      
            protected override void OnPaint(PaintEventArgs pe)  
            {  
                base.OnPaint(pe);  
                text = this.Text;  
                if (textX == 100 && textY == 25)  
                {  
                    textX = ((this.Width) / 3) + 10;  
                    textY = (this.Height / 2) - 1;  
                }  
                Color c1 = Color.FromArgb(color1Transparent, color1);  
                Color c2 = Color.FromArgb(color2Transparent, color2);  
                //drawing string & filling gradient rectangle   
                Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, c1, c2, angle);  
                Point p = new Point(textX, textY);  
                SolidBrush frcolor = new SolidBrush(this.ForeColor);  
                Border3DStyle borderStyle = Border3DStyle.SunkenInner;  
                pe.Graphics.FillRectangle(b, ClientRectangle);  
                pe.Graphics.DrawString(text, this.Font, frcolor, p);  
                ControlPaint.DrawBorder3D(pe.Graphics, ClientRectangle, borderStyle);  
                b.Dispose();  
            }  
      
        }  
    }  
