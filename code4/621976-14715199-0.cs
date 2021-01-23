        Point startPoint;
        Point currentPoint;
        bool draw = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            draw = true;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            currentPoint = e.Location;
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (draw)
            {
                int startX = Math.Min(startPoint.X, currentPoint.X);
                int startY = Math.Min(startPoint.Y, currentPoint.Y);
                int endX = Math.Max(startPoint.X, currentPoint.X);
                int endY = Math.Max(startPoint.Y, currentPoint.Y);
                e.Graphics.DrawRectangle(Pens.Orange, new Rectangle(startX, startY, endX-startX, endY-startY));
            }
        }
