    Canvas.MouseMove += (sender, args) =>
    {
        if (args.LeftButton == MouseButtonState.Pressed)
        {
            Polyline polyLine;
            if (PathModeCanvas.Children.Count == 0)
            {
                polyLine = new Polyline();
                polyLine.Stroke = new SolidColorBrush(Colors.AliceBlue);
                polyLine.StrokeThickness = 10;
                Canvas.Children.Add(polyLine);
            }
            polyLine = (Polyline)Canvas.Children[0];
            Point currentPoint = args.GetPosition(Canvas);
            polyLine.Points.Add(currentPoint);
       }
    };
