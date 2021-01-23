    public void line_MouseUp(object sender, MouseButtonEventArgs e)
    {
        Point newPos = e.GetPosition(canvas1);
        line.X1 += newPos.X - p.X;
        line.X2 += newPos.X - p.X;
        line.Y1 += newPos.Y - p.Y;
        line.Y2 += newPos.Y - p.Y;
        isdragging = false;
    }
