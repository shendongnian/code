    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        Point[] points = new[] { 
                new Point(0, 200),
                new Point(0, 0),
                new Point(300, 0),
                new Point(350, 200),
                new Point(400, 0)
            };
        var b = GetBezierApproximation(points, 256);
        PathFigure pf = new PathFigure(b.Points[0], new[] { b }, false);
        PathFigureCollection pfc = new PathFigureCollection();
        pfc.Add(pf);
        var pge = new PathGeometry();
        pge.Figures = pfc;
        Path p = new Path();
        p.Data = pge;
        p.Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        ((Grid)sender).Children.Add(p);
    }
