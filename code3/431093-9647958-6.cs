    Point? prevPosition = null;
    ToolTip tooltip = new ToolTip();
    
    void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        var pos = e.Location;
        if (prevPosition.HasValue && pos == prevPosition.Value)
            return;
        tooltip.RemoveAll();
        prevPosition = pos;
        var results = chart1.HitTest(pos.X, pos.Y, false, 
                                     ChartElementType.PlottingArea);
        foreach (var result in results)
        {
            if (result.ChartElementType == ChartElementType.PlottingArea)
            {
                var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
    
                tooltip.Show("X=" + xVal + ", Y=" + yVal, this.chart1, 
                             pos.X, pos.Y - 15);
            }
        }
    }
