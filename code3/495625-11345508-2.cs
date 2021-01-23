    if (p.X > myPoints[0].X)//right
    {
        if (p.Y + bdr.ActualHeight> myPoints[0].Y)//lower
        {
            myPoints.Add(new Point(p.X, p.Y + 50));
            myPoints.Add(new Point(p.X, p.Y + 25));
        }
        else//higher
        {
            myPoints.Add(new Point(p.X, p.Y + bdr.ActualHeight- 50));
            myPoints.Add(new Point(p.X, p.Y + bdr.ActualHeight - 25));
        }
    }
    else if (p.X + bdr.ActualWidth > myPoints[0].X)//Middle
    {
        if (p.Y + bdr.ActualHeight > myPoints[0].Y)//lower
        {
            myPoints.Add(new Point(p.X + (bdr.ActualWidth / 2) + 25, p.Y));
            myPoints.Add(new Point(p.X + (bdr.ActualWidth / 2), p.Y));
        }
        else if (p.Y + bdr.ActualHeight < myPoints[0].Y)//higher
        {
            myPoints.Add(new Point(p.X + (bdr.ActualWidth / 2) + 25, p.Y + bdr.ActualHeight));
            myPoints.Add(new Point(p.X + (bdr.ActualWidth / 2), p.Y + bdr.ActualHeight));
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
