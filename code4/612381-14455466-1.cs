    private void Chart_MouseClick(object sender, MouseButtonEventArgs e)
    {
        LineSeries line = (LineSeries)mychart.Series[0];
        Point point = e.GetPosition(line);
        Int32? selectIndex = FindNearestPointIndex(line.Points, point);
        // ...
    }
    private Int32? FindNearestPointIndex(PointCollection points, Point point)
    {
        if ((points == null || (points.Count == 0))
            return null;
        Func<Point, Point, Double> getLength = (p1, p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)); // C^2 = A^2 + B^2
        List<Points> results = points.Select((p,i) => new { Point = p, Length = getLength(p, point), Index = i }).ToList();
        Int32 minLength = results.Min(i => i.Length);
        return results.First(i => (i.Length == minLength)).Index;
    }
