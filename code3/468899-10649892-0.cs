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
                                        ChartElementType.DataPoint);
        foreach (var result in results)
        {
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var prop = result.Object as DataPoint;
                if (prop != null)
                {
                    var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                    var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);
                    // check if the cursor is really close to the point (2 pixels around the point)
                    if (Math.Abs(pos.X - pointXPixel) < 2 &&
                        Math.Abs(pos.Y - pointYPixel) < 2)
                    {
                        tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.chart1,
                                        pos.X, pos.Y - 15);
                    }
                }
            }
        }
    }
