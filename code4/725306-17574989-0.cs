    void MainWindow_MouseMove(object sender, MouseEventArgs e)
    {
        var cellSize = new Size(20, 20);
        var mousePos = e.GetPosition(this);
    
        Console.WriteLine(GetSnappingPoint(mousePos,cellSize));
    
    }
    
    /// <summary>
    /// Get snapping point by
    /// </summary>
    Point GetSnappingPoint(Point mouse,Size cellSize)
    {
        //Get x interval based on cell width
        var xInterval = GetInterval(mouse.X, cellSize.Width);
    
        //Get y interal based in cell height
        var yInterval = GetInterval(mouse.Y, cellSize.Height);
    
        // return the point on cell grid closest to the mouseposition
        return new Point()
        {
            X = Math.Abs(xInterval.Lower - mouse.X) > Math.Abs(xInterval.Upper - mouse.X) ? xInterval.Upper : xInterval.Lower,
            Y = Math.Abs(yInterval.Lower - mouse.Y) > Math.Abs(yInterval.Upper - mouse.Y) ? yInterval.Upper : yInterval.Lower,
        };
    }
    
    /// <summary>
    ///  Find an interval of the celsize based on mouse position and size
    /// </summary>
    Interval GetInterval(double mousePos,double size)
    {
        return new Interval()
        {
            Lower = ((int)(mousePos / size)) * size,
            Upper = ((int)(mousePos / size)) * size + size
        };
    }
    
    /// <summary>
    /// Basic interval class
    /// </summary>
    class Interval
    {
        public double Lower { get; set; }
        public double Upper { get; set; }
    }
