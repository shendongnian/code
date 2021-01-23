    element.Measure(new Size(canvas.Width, canvas.Height));
    var line = new Line { StrokeThickness = 2, Stroke = new SolidColorBrush(Colors.Black) };
    line.X1 = 0.0;
    line.Y1 = element.ActualHeight;
    line.Y2 = 0.0;
    line.X2 = element.ActualWidth;
    // Insert the element straight after the element it's bound to
    canvas.Children.Insert(canvas.Children.IndexOf(element) + 1, line);
    line.SetValue(Canvas.TopProperty, element.GetValue(Canvas.TopProperty));
    line.SetValue(Canvas.LeftProperty, element.GetValue(Canvas.LeftProperty));
    // and make sure it's Z index is always higher
    line.SetValue(Canvas.ZIndexProperty, (int)element.GetValue(Canvas.ZIndexProperty) + 1);
    line.Height = element.ActualHeight;
    line.Width = element.ActualWidth;
