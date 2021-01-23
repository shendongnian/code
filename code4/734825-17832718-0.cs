    List<Point> newList = new List<Point>();
    foreach(Point p in points)
    {
      Point sumsXYPoint = sumsXY.FirstOrDefault(sums => sums.Id == p.Id);
      if (sumsXYPoint != null)
      {
        newList.Add(new Point() { Id = p.Id, X = sumsXYPoint.X + p.X, Y = sumsXYPoint.Y + p.Y);
      }
    }
