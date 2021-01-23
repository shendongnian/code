    Line line = new Line();
    line.Stroke = new SolidColorBrush(Colors.Purple);
    line.StrokeThickness = 15;
     
    Point point1 = new Point();
    point1.X = 10.0;
    point1.Y = 100.0;
     
    Point point2 = new Point();
    point2.X = 150.0;
    point2.Y = 100.0;
     
    line.X1 = point1.X;
    line.Y1 = point1.Y;
    line.X2 = point2.X;
    line.Y2 = point2.Y;
         
    this.ContentPanelCanvas.Children.Add(line);
