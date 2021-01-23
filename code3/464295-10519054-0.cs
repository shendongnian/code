    PathFigure myPathFigure = new PathFigure();
    myPathFigure.StartPoint = new Point(10,50);
    myPathFigure.Segments.Add(
       new ArcSegment(
           new Point(200,100),
           new Size(50,50),
           45,
           true, /* IsLargeArc */ 
           SweepDirection.Clockwise, 
           true /* IsStroked */ ));                       
