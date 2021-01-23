    GeometryGroup gg = new GeometryGroup();            
    gg.Children.Add(new RectangleGeometry(new Rect(0, 0, 100, 100)));
    gg.Children.Add(new RectangleGeometry(new Rect(100, 100, 100, 100)));
    gg.Children.Add(new RectangleGeometry(new Rect(200, 200, 100, 100)));
    System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
    path.Data = gg;
    path.Fill = Brushes.Blue;
