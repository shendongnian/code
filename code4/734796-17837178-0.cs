    //Build up
    chart1.Series.Clear();
    chart1.ChartAreas.Clear();
    chart1.Series.Add("S");
    chart1.ChartAreas.Add("A");
    chart1.Series["S"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
    //Creating test data
    chart1.Series["S"].Points.AddXY("1", 5);
    chart1.Series["S"].Points.AddXY("0", 3);
    chart1.Series["S"].Points.AddXY("1", 6);
    chart1.Series["S"].Points.AddXY("0", 4);
    chart1.Series["S"].Points.AddXY("1", 1);
    //Changing labels
    foreach (var p in chart1.Series["S"].Points)
    {
        p.AxisLabel = (p.AxisLabel == "1") ? "Success" : "Failure";
    }
