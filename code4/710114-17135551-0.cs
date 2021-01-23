        private void onPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rc = new Rectangle(50, 10, 400, 400);
            using (Pen p = new Pen(System.Drawing.Color.Black, 2))
            {
                g.DrawRectangle(p, rc);
                g.DrawLine(p, rc.Left, rc.Top, rc.Right, rc.Bottom);
            }
        }
