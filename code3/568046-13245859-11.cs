        Point dragPoint = Point.Empty;
        bool dragging = false;
        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragPoint = new Point(e.X, e.Y);
        }
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
                pic.Location = new Point(pic.Location.X + e.X - dragPoint.X, pic.Location.Y + e.Y - dragPoint.Y);
        }
        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
