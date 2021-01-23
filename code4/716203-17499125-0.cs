        private void DrawMarker(int X, int Y, double Scale, Color BorderColor, Color FillColor, PaintEventArgs e, char Letter = '\0')
        {
            Graphics G1 = e.Graphics;
            Pen Pen1 = new Pen(BorderColor, 8);
            SolidBrush Brush1 = new SolidBrush(BorderColor);
            SolidBrush Brush2 = new SolidBrush(FillColor);
            G1.SmoothingMode = SmoothingMode.AntiAlias;
            G1.ResetTransform();
            G1.ScaleTransform(Convert.ToSingle(0.4 * Scale), Convert.ToSingle(0.4 * Scale));
            GraphicsPath GraphicsPath1 = new GraphicsPath();
            GraphicsPath1.AddBeziers(new Point(X + 51, Y + 169), new Point(X + 47, Y + 137), new Point(X + 42, Y + 107), new Point(X + 14, Y + 77));
            GraphicsPath1.AddBeziers(new Point(X + 87, Y + 77), new Point(X + 62, Y + 107), new Point(X + 55, Y + 137), new Point(X + 51, Y + 169));
            
            GraphicsPath GraphicsPath2 = new GraphicsPath();
            GraphicsPath2.AddEllipse(X + 5, Y + 5, 92, 92);
            G1.FillPath(Brush2, GraphicsPath2);
            G1.DrawPath(Pen1, GraphicsPath2);
            G1.SetClip(new Rectangle(X, Y + 85, 103, 84));
            G1.FillPath(Brush2, GraphicsPath1);
            G1.DrawPath(Pen1, GraphicsPath1);
            G1.ResetClip();
            if (Letter != '\0')
            {
                Font Font1 = new Font("Arial", 52, FontStyle.Bold);
                StringFormat StringFormat1 = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                G1.DrawString(Convert.ToString(Letter), Font1, Brush1, new Rectangle(X, Y, 103, 103), StringFormat1);
                Font1.Dispose();
                StringFormat1.Dispose();
            }
            else
            {
                G1.FillEllipse(Brush1, new Rectangle(X + 32, Y + 32, 37, 37));
            }
            Pen1.Dispose();
            Brush1.Dispose();
            Brush2.Dispose();
            GraphicsPath1.Dispose();
            GraphicsPath2.Dispose();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawMarker(0, 0, 0.5, Color.Black, Color.Tomato, e, Convert.ToChar("A"));
            DrawMarker(80, 0, 0.8, Color.Black, Color.Red, e, Convert.ToChar("B"));
            DrawMarker(160, 0, 1, Color.Black, Color.Linen, e, Convert.ToChar("C"));
            DrawMarker(210, 0, 1.3, Color.Black, Color.Orange, e, Convert.ToChar("D"));
            DrawMarker(260, 0, 1.6, Color.Black, Color.Green, e);
        }
