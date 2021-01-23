            r1 = new Rectangle();
            r1.Margin = new Thickness(50, 50, 0, 0);
            r1.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            r1.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            r1.Height = 50;
            r1.Width= 50;
            r1.Fill = new SolidColorBrush(Colors.Red);
            r2 = new Rectangle();
            r2.Width = 50;
            r2.Height = 50;
            r2.Fill = new SolidColorBrush(Colors.Blue);
            r2.Margin = new Thickness(350, 450, 0, 0);
            r2.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            r2.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            l = new Line();
            l.X1 = 75;
            l.Y1 = 75;
            l.X2 = 375;
            l.Y2 = 475;
            l.Fill = new SolidColorBrush(Colors.Purple);
            l.Stroke = new SolidColorBrush(Colors.Purple);
            l.StrokeThickness = 2;
            l.SetValue(Canvas.ZIndexProperty, -1);
            PathGeometry myPathGeometry = new PathGeometry();
            // Create a figure.
            PathFigure pathFigure1 = new PathFigure();
            pathFigure1.StartPoint = new Point(75, 75);
            pathFigure1.Segments.Add(
                new ArcSegment(
                    new Point(375, 475),
                    new Size(50, 50),
                    45,
                    true, /* IsLargeArc */
                    SweepDirection.Clockwise,
                    true /* IsStroked */ ));
            myPathGeometry.Figures.Add(pathFigure1);
            // Display the PathGeometry. 
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myPathGeometry;
            myPath.SetValue(Canvas.ZIndexProperty, -1);
            LayoutRoot.Children.Add(r1);
            LayoutRoot.Children.Add(r2);
            LayoutRoot.Children.Add(l);
            LayoutRoot.Children.Add(myPath);
