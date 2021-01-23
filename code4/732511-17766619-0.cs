    BezierSegment curve = new BezierSegment(new Point(11,11), new Point(22,22), new Point(15,15), false);           
    // Set up the Path to insert the segments
    PathGeometry path = new PathGeometry();
    PathFigure pathFigure = new PathFigure();
    pathFigure.StartPoint = new Point(11, 11);
    pathFigure.IsClosed = true;
    path.Figures.Add(pathFigure);
    pathFigure.Segments.Add(curve);
    System.Windows.Shapes.Path p = new Path();
    p.Stroke = Brushes.Red;
    p.Data = path;
    MyCanvas.Children.Add(p); // Here
