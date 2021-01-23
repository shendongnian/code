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
        var dic = new Dictionary<Tuple<Point, Point>, Func<int, double>>
                      {
                          {Tuple.Create(pt1, pt2), CreateFunc(pt1, pt2)},
                          {Tuple.Create(pt1, pt3), CreateFunc(pt1, pt3)},
                          {Tuple.Create(pt2, pt3), CreateFunc(pt2, pt3)},
                      };
        var yRanges = new Dictionary<int, double>();
        foreach (var kvp in dic)
        {
            if (kvp.Key.Item1.X == kvp.Key.Item2.X)
            {
                var minY = Math.Min(kvp.Key.Item1.Y, kvp.Key.Item2.Y);
                var maxY = Math.Max(kvp.Key.Item1.Y, kvp.Key.Item2.Y);
                for (var y = minY; y <= maxY; y++)
                {
                    var pt = new Point(kvp.Key.Item1.X, y);
                    if (pt != pt1 && pt != pt2 && pt != pt3)
                    {
                        yield return pt;
                    }
                }
            }
            var minX = Math.Min(kvp.Key.Item1.X, kvp.Key.Item2.X);
            var maxX = Math.Max(kvp.Key.Item1.X, kvp.Key.Item2.X);
            for (var x = minX; x <= maxX; x++)
            {
                var y1 = kvp.Value(x);
                double y2;
                if (yRanges.TryGetValue(x, out y2))
                {
                    var minY = (int)Math.Ceiling(Math.Min(y1, y2));
                    var maxY = (int)Math.Floor(Math.Max(y1, y2));
                    foreach (var y in Enumerable.Range(minY, maxY - minY + 1))
                    {
                        var pt = new Point(x, y);
                        if (pt != pt1 && pt != pt2 && pt != pt3)
                        {
                            yield return pt;
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
        if (pt1.Y == pt2.Y)
        {
            return x => pt1.Y;
        }
        return x => (double)(pt2.Y - pt1.Y) / (pt2.X - pt1.X) *
                    (x - pt1.X) + pt1.Y;
    }
