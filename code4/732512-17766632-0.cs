     System.Windows.Shapes.Path p = new Path();
     p.Data = path;
     p.Fill = System.Windows.Media.Brushes.Green;
     p.Stroke = System.Windows.Media.Brushes.Blue;
     p.StrokeThickness = 1;
     this.MyCanvas.Children.Add(p);
