    Point dragPoint = Point.Empty;
        bool dragging = false;
        bool mouseDown = false;
        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            dragPoint = new Point(e.X, e.Y);
        }
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            int deltaX = e.X - dragPoint.X;
            int deltaY = e.Y - dragPoint.Y;
            if (mouseDown && deltaX * deltaX + deltaY * deltaY > 100)
                dragging = true;
            
            if (dragging)
                pic.Location = new Point(pic.Location.X + deltaX, pic.Location.Y + deltaY);
        }
        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            mouseDown = false;
        }
