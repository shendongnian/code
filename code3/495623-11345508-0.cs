    if (p.X > myPoints[0].X)//right
    {
        if (p.Y > myPoints[0].Y)//lower
        {
            myPoints.Add(new Point(p.X, p.Y + 50));
            myPoints.Add(new Point(p.X, p.Y + 25));
        }
        else//higher
        {
            myPoints.Add(new Point(p.X, p.Y + 250));
            myPoints.Add(new Point(p.X, p.Y + 225));
        }
    }
    else//left
    {
        if (p.Y > myPoints[0].Y)//lower
        {
            myPoints.Add(new Point(p.X + bdr.ActualWidth, p.Y + 50));
            myPoints.Add(new Point(p.X + bdr.ActualWidth, p.Y + 25));
        }
        else//higher
        {
            myPoints.Add(new Point(p.X + bdr.ActualWidth, p.Y + 50));
            myPoints.Add(new Point(p.X + bdr.ActualWidth, p.Y + 25));
        }
    }
