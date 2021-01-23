            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawArc(new Pen(Brushes.Black, 10), new Rectangle(50, 50, 100,100),10, 340);
                e.Graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(142, 85, 14, 30));
            }
