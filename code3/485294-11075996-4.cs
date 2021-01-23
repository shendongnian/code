    public IEnumerable<Point> PointsInTriangle(Point pt1, Point pt2, Point pt3)
    {
        if (pt1.Y == pt2.Y && pt1.Y == pt3.Y)
        {
            throw new ArgumentException("The given points must form a triangle.");
        }
        var pts = new[] {pt1, pt2, pt3}.OrderBy(pt => pt.X).ToArray();
        pt1 = pts[0];
        pt2 = pts[1];
        pt3 = pts[2];
        // The base line is the one that includes all X values within the triangle
        var baseFunc = CreateFunc(pt1, pt3);
        // The first and second line are the two other lines of the triangle
        var line1Func = pt1.X == pt2.X ? (x => pt2.Y) : CreateFunc(pt1, pt2);
        var line2Func = pt2.X == pt3.X ? (x => pt2.Y) : CreateFunc(pt2, pt3);
        for (int i = 0; i < 2; i++)
        {
            int minX, maxX;
            Func<int, double> lineFunc;
            if (i == 0)
            {
                minX = pt1.X;
                maxX = pt2.X;
                lineFunc = line1Func;
            }
            else
            {
                minX = pt2.X + 1;
                maxX = pt3.X;
                lineFunc = line2Func;
            }
            for (int x = minX; x <= maxX; x++)
            {
                var baseY = baseFunc(x);
                var lineY = lineFunc(x);
                int minY, maxY;
                if (baseY < lineY)
                {
                    minY = (int)Math.Ceiling(baseY);
                    maxY = (int)Math.Floor(lineY);
                }
                else
                {
                    minY = (int)Math.Ceiling(lineY);
                    maxY = (int)Math.Floor(baseY);
                }
                for (var y = minY; y <= maxY; y++)
                {
                    yield return new Point(x, y);
                }
            }
        }
    }
    private Func<int, double> CreateFunc(Point pt1, Point pt2)
    {
        var y0 = pt1.Y;
        if (y0 == pt2.Y)
        {
            return x => y0;
        }
        var m = (double)(pt2.Y - y0) / (pt2.X - pt1.X);
        return x => m * (x - pt1.X) + y0;
    }
