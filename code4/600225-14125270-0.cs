    // to disable the series use this method instead of series.Enabled
    private SetSeriesEnabled(Series series, bool enable)
    { 
        series.Tag = enabled;
        this.chart1.Invalidate();
    }
    private Dictionary<string, Color> originalSeriesColors;
    void chart1_PrePaint(object sender, ChartPaintEventArgs e)
    {
        // initialize the original colors dictionary
        if (originalSeriesColors == null)
        {
            originalSeriesColors = new Dictionary<string, Color>();
            foreach (var s in this.chart1.Series)
                originalSeriesColors.Add(s.Name, s.Color);
        }
        var series = e.ChartElement as Series;
        if (series != null)
        {
            var origColor = originalSeriesColors[series.Name];
            if (series.Tag is bool && (bool)series.Tag == false)
            {
                // set series color to semi-transparent (so the legend will be opaque)
                series.Color = Color.FromArgb(100, origColor);
                // set points color to transparent
                foreach(var pt in series.Points)
                    pt.Color = Color.Transparent;
            }
            else
            {
                // reset everything to original color
                series.Color = origColor;
                foreach (var pt in series.Points)
                    pt.Color = origColor;
            }
        }
    }
