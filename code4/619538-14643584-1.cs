      private void Form1_Load(object sender, EventArgs e)
        {
            myGroupBox myGroupBox = new myGroupBox();
            myGroupBox.Text = "GroupBox1";
           
            this.Controls.Add(myGroupBox);
         
        }
        public static GraphicsPath CreatePath(float x, float y, float width, float height,
                                      float radius, bool RoundTopLeft, bool RoundTopRight, bool RoundBottomRight, bool RoundBottomLeft)
        {
            float xw = x + width;
            float yh = y + height;
            float xwr = xw - radius;
            float yhr = yh - radius;
            float xr = x + radius;
            float yr = y + radius;
            float r2 = radius * 2;
            float xwr2 = xw - r2;
            float yhr2 = yh - r2;
            GraphicsPath p = new GraphicsPath();
            p.StartFigure();
            //Top Left Corner
            if (RoundTopLeft)
            {
                p.AddArc(x, y, r2, r2, 180, 90);
            }
            else
            {
                p.AddLine(x, yr, x, y);
                p.AddLine(x, y, xr, y);
            }
            //Top Edge
            p.AddLine(xr, y, xwr, y);
            //Top Right Corner
            if (RoundTopRight)
            {
                p.AddArc(xwr2, y, r2, r2, 270, 90);
            }
            else
            {
                p.AddLine(xwr, y, xw, y);
                p.AddLine(xw, y, xw, yr);
            }
            //Right Edge
            p.AddLine(xw, yr, xw, yhr);
            //Bottom Right Corner
            if (RoundBottomRight)
            {
                p.AddArc(xwr2, yhr2, r2, r2, 0, 90);
            }
            else
            {
                p.AddLine(xw, yhr, xw, yh);
                p.AddLine(xw, yh, xwr, yh);
            }
            //Bottom Edge
            p.AddLine(xwr, yh, xr, yh);
            //Bottom Left Corner           
            if (RoundBottomLeft)
            {
                p.AddArc(x, yhr2, r2, r2, 90, 90);
            }
            else
            {
                p.AddLine(xr, yh, x, yh);
                p.AddLine(x, yh, x, yhr);
            }
            //Left Edge
            p.AddLine(x, yhr, x, yr);
            p.CloseFigure();
            return p;
        }
        class myGroupBox : GroupBox
        {
            public myGroupBox()
            {
                base.BackColor = Color.Transparent;
            }
            [Browsable(false)]
            public override Color BackColor
            {
                get
                {
                    return base.BackColor;
                }
                set
                {
                    base.BackColor = value;
                }
            }
            private Color backColor = Color.Transparent;
            public Color ActualBackColor
            {
                get { return this.backColor; }
                set { this.backColor = value; }
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                Size tSize = TextRenderer.MeasureText(this.Text, this.Font);
                Rectangle borderRect = e.ClipRectangle;
                borderRect.Y += tSize.Height / 2;
                borderRect.Height -= tSize.Height / 2;
                GraphicsPath gPath = CreatePath(0, borderRect.Y, (float)(this.Width - 1), borderRect.Height - 1, 5, true, true, true, true);
                e.Graphics.FillPath(new SolidBrush(ActualBackColor), gPath);
                e.Graphics.DrawPath(new Pen(Color.Red), gPath);
                borderRect.X += 6;
                borderRect.Y -= 7;
                e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), borderRect);
            }
        }
