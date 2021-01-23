    void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
    {
        var axisY = this.chart1.ChartAreas[0].AxisY;
    
        var xRangeStart = e.Axis.ScaleView.ViewMinimum;
        var xRangeEnd = e.Axis.ScaleView.ViewMaximum;
    
        // compute the Y values for the points crossing the range edges
        double? yRangeStart = null;
        var pointBeforeRangeStart = this.chart1.Series[0].Points.FirstOrDefault(x => x.XValue <= xRangeStart);
        var pointAfterRangeStart = this.chart1.Series[0].Points.FirstOrDefault(x => x.XValue > xRangeStart);
        if (pointBeforeRangeStart != null && pointAfterRangeStart != null)
            yRangeStart = Interpolate2Points(pointBeforeRangeStart, pointAfterRangeStart, xRangeStart);
    
        double? yRangeEnd = null;
        var pointBeforeRangeEnd = this.chart1.Series[0].Points.FirstOrDefault(x => x.XValue <= xRangeEnd);
        var pointAfterRangeEnd = this.chart1.Series[0].Points.FirstOrDefault(x => x.XValue > xRangeEnd);
        if (pointBeforeRangeEnd != null && pointAfterRangeEnd != null)
            yRangeEnd = Interpolate2Points(pointBeforeRangeEnd, pointAfterRangeEnd, xRangeEnd);
    
        var edgeValues = new[] { yRangeStart, yRangeEnd }.Where(x => x.HasValue).Select(x => x.Value);
    
        // find the points inside the range
        var valuesInRange = this.chart1.Series[0].Points
        .Where(p => p.XValue >= xRangeStart && p.XValue <= xRangeEnd)
        .Select(x => x.YValues[0]);
    
        // find the minimum and maximum Y values
        var values = valuesInRange.Concat(edgeValues);
        double yMin;
        double yMax;
        if (values.Any())
        {
            yMin = values.Min();
            yMax = values.Max();
        }
        else
        {
            yMin = this.chart1.Series[0].Points.Min(x => x.YValues[0]);
            yMax = this.chart1.Series[0].Points.Max(x => x.YValues[0]);
        }
    
        // zoom Y-axis to [yMin - yMax]
        axisY.ScaleView.Zoom(yMin, yMax);
    }
    
    // see: http://en.wikipedia.org/wiki/Linear_interpolation#Linear_interpolation_between_two_known_points
    public static double Interpolate2Points(DataPoint p1, DataPoint p2, double x)
    {
        var x0 = p1.XValue;
        var y0 = p1.YValues[0];
        var x1 = p2.XValue;
        var y1 = p2.YValues[0];
        return y0 + ((x - x0) * y1 - (x - x0) * y0) / (x1 - x0);
    }
