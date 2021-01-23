    List<Point> points = new List<Point>();
    List<Point> sumsXY = new List<Point>();
    points.Add(new Point(1, 10, 10));
    points.Add(new Point(2, 10, 20));
    points.Add(new Point(3, 10, 30));
    sumsXY.Add(new Point(1, 100, 100));
    sumsXY.Add(new Point(5, 10, 20));
    sumsXY.Add(new Point(6, 10, 30));
    foreach (Point p in points)
    {
         foreach (Point s in sumsXY)
         {
             if (s.Id == p.Id)
             {
                 s.X += p.X;
                 s.Y += p.Y;
             }
         }
     }
