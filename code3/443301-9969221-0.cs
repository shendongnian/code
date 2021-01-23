    public void Test()
    {
     List<Point> points = new List<Point>
     {
      new Point(0, 10),
      new Point(1, 12),
      new Point(2, 16),
      new Point(3, 16),
      new Point(4, 16),
      new Point(5, 13),
      new Point(6, 16),
     };
     var subSetOfPoints = points.Where(p=> !IsInTheMiddleX(p, points));
    }
            
    private bool IsInTheMiddleX(Point point, IEnumerable<Point> points)
    {
     return points.Any(p => p.X < point.X && p.Y == point.Y) && 
            points.Any(p => p.X > point.X && p.Y == point.Y);                        
    }
