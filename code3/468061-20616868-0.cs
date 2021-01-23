    using System.Windows.Forms.DataVisualization.Charting;
    private void CreateChart()
    {
        var series = new Series("Finance");
        // Frist parameter is X-Axis and Second is Collection of Y- Axis
        series.Points.DataBindXY(new[] { 2001, 2002, 2003, 2004 }, new[] { 100, 200, 90, 150 });
        chart1.Series.Add(series);
    }
