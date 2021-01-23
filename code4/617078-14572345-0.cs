    public void line_MouseMove(object sender, MouseEventArgs e)
    {
        if (isdragging == true && e.LeftButton == MouseButtonState.Pressed)
        {
            Point newPos = e.GetPosition(canvas1);
            if (Size(p, newPos) > 10)
            {
                line.X1 += newPos.X - p.X;
                line.X2 += newPos.X - p.X;
                line.Y1 += newPos.Y - p.Y;
                line.Y2 += newPos.Y - p.Y;
                p = newPos;
            }
        }
    }
