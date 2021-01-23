    public IEnumerable<Point> PointsInTriangle(Point pt1, Point pt2, Point pt3)
    {
        if (pt1.Y == pt2.Y && pt1.Y == pt3.Y)
        {
            throw new ArgumentException("The given points must form a triangle.");
        }
        // The edges are obviously a part of the triangle
        yield return pt1;
        yield return pt2;
        yield return pt3;
        var linesFuncs = new[]
                         {
                             Tuple.Create(Tuple.Create(pt1, pt2), CreateFunc(pt1, pt2)),
                             Tuple.Create(Tuple.Create(pt1, pt3), CreateFunc(pt1, pt3)),
                             Tuple.Create(Tuple.Create(pt2, pt3), CreateFunc(pt2, pt3))
                         };
        var yRanges = new Dictionary<int, double>();
        foreach (var kvp in linesFuncs)
        {
            if (kvp.Item1.Item1.X == kvp.Item1.Item2.X)
            {
                continue;
            }
            var minX = Math.Min(kvp.Item1.Item1.X, kvp.Item1.Item2.X);
            var maxX = Math.Max(kvp.Item1.Item1.X, kvp.Item1.Item2.X);
            for (var x = minX; x <= maxX; x++)
            {
                var y1 = kvp.Item2(x);
                double y2;
                if (yRanges.TryGetValue(x, out y2))
                {
                    var minY = (int)Math.Ceiling(Math.Min(y1, y2));
                    var maxY = (int)Math.Floor(Math.Max(y1, y2));
                    for (var y = minY; y <= maxY; y++)
                    {
                        if ((x != pt1.X || y != pt1.Y) &&
                            (x != pt2.X || y != pt2.Y) &&
                            (x != pt3.X || y != pt3.Y))
                        {
                            yield return new Point(x, y);
                        }
                    }
                }
                else
                {
                    yRanges.Add(x, y1);
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
