    Rect myrectangel = new Rect(0, 0, 200, 200);
    PathGeometry geom = new PathGeometry();
    Geometry g = new RectangleGeometry(myrectangel);
    geom.AddGeometry(g);
    System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
    path.Fill = Brushes.Blue;
    path.Data = geom;
