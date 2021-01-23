    /// <summary>
    /// When left shift key is pressed we snap the mouse to the closest
    /// intersection
    /// </summary>
    void MainWindow_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.LeftShift)
        {
            var p = GetSnappingPoint(Mouse.GetPosition(this), new Size(200, 200));
            SetCursorPos((int)p.X, (int)p.Y+20);
        }
    
    }
    [DllImport("User32.dll")]
    private static extern bool SetCursorPos(int x, int y);
        
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
