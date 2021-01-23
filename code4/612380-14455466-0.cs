    private void Chart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        LineSeries line = (LineSeries)mychart.Series[0];
        Point point = e.GetPosition(line);
        Int32? selectIndex = this.FindNearestPointIndex(line.Points, newPoint);
        // ...
    }
    private Int32? FindNearestPointIndex(PointCollection points, Point p)
    {
        if (points == null || (points.Count == 0))
            return null;
        Func<Point, Point, Double> getLength = (p1, p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        var items = points.Select((p,i) => new { Point = p, Length = getLength(p, newPoint), Index = i });
        Int32 minLength = items.Min(item => item.Length);
        return items.First(item => item.Length == minLength).Index;
    }
