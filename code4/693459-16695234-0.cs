        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            string text = "this is distribute";
            Rectangle displayRectangle = new Rectangle(new Point(40, 40), new Size(400, 80));
            e.Graphics.DrawRectangle(Pens.Black, displayRectangle);
            int step = displayRectangle.Width / text.Length;
            SizeF szF = e.Graphics.MeasureString(text, this.Font); // just to get the HEIGHT
            int y = (displayRectangle.Y + displayRectangle.Height / 2) - (int)szF.Height / 2;
            for (int i = 0; i < text.Length; i++)
            {
                e.Graphics.DrawString(text.Substring(i, 1), this.Font, Brushes.Black, displayRectangle.X + (i * step), y);
            }
        }
