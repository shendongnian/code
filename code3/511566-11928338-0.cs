    //chart1.ChartAreas[0].AxisY.Crossing = Double.MaxValue; // Disabled - from your example.
    chart1.ChartAreas[0].AxisY.IsReversed = true;
    chart1.Series[0].XAxisType = AxisType.Secondary;
    // Example data for image below
    chart1.Series[0].ChartType = SeriesChartType.Spline;
    chart1.Series[0].Points.Add(new DataPoint(1, 0));
    chart1.Series[0].Points.Add(new DataPoint(2, 40));
    chart1.Series[0].Points.Add(new DataPoint(3, 20));
    chart1.Series[0].Points.Add(new DataPoint(4, 90));
    chart1.Series[0].Points.Add(new DataPoint(5, 20));
