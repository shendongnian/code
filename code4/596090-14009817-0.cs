    void renderLine(Point p1, Point p2)
    {
        List<Point> points = pointsOnLine(p1, p2);
        int dx = Abs(p2.x - p1.x);
        int dy = Abs(p2.y - p1.y);
    
        Rectangle selection = world.SelectionRectangle;
        int incr = selection.Width / world.Settings.TileSize.Width;
        if(dy > dx)
        {
            incr = selection.Height / world.Settings.TileSize.Height;
        }
        int lastPoint = points.Count / incr;
        lastPoint *= incr;
        for (int i = 0; i <= lastPoint; i+=incr)
            renderPoint(points[i], i == lastPoint);
    }
