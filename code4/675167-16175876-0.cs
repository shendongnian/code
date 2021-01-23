            Path path = new Path();
            EllipseGeometry eg = new EllipseGeometry();
            eg.Center = new Point(left + side / 2, top + side / 2);
            eg.RadiusX = side / 2;
            eg.RadiusY = side / 2;
            path.Data = eg;
            paths.Add(path);
            canvas1.Children.Add(paths[paths.Count - 1]);
            .
            .
            path = new Path();
            borderColor.Color = Colors.Red;
            path.Stroke = borderColor;
            path.StrokeThickness = 2;
            LineGeometry r = new LineGeometry();
            r.StartPoint = eg.Center;
            r.EndPoint = new Point(eg.Center.X + eg.RadiusX, eg.Center.Y);
            path.Data = r;
            paths.Add(path);
            canvas1.Children.Add(paths[paths.Count - 1]);
            
