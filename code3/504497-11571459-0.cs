    /// <summary>
    /// Creates a line at run-time
    /// </summary>
    public void CreateALine()
    {
       // Create a Line
       Line redLine = new Line();
       redLine.X1 = 50;
       redLine.Y1 = 50;
       redLine.X2 = 200;
       redLine.Y2 = 200;
       // Create a red Brush
       SolidColorBrush redBrush = new SolidColorBrush();
       redBrush.Color = Colors.Red;
       // Set Line's width and color
       redLine.StrokeThickness = 4;
       redLine.Stroke = redBrush;
       // Add line to the Grid.
       LayoutRoot.Children.Add(redLine);
    }
