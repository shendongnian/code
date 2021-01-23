    List<Point> dots = new List<Point>();
    int totalX = 0, totalY = 0;
    foreach (Point p in dots)
    {
    	totalX += p.X;
    	totalY += p.Y;
    }
    int centerX = totalX / dots.Count;
    int centerY = totalY / dots.Count;
