    DateTime firstDay = new DateTime(2013, 01, 01);
    DateTime secondDay = new DateTime(2013, 01, 02);
    int[] group1 = new int[6] { 1, 6, 7, 5, 4, 9 };
    int[] group2 = new int[6] { 2, 5, 8, 6, 8, 3 };
    DateTime[] days = new DateTime[6] { firstDay, firstDay, firstDay, secondDay, secondDay, secondDay};
    chart.Series.Add(new Series("Group 1"));
    chart.Series[0].Points.DataBindXY(days, group1);
    chart.Series[0].ChartType = SeriesChartType.Column;
    chart.Series.Add(new Series("Group 2"));
    chart.Series[1].Points.DataBindXY(days, group2);
    chart.Series[1].ChartType = SeriesChartType.Column;
    double start = chart.Series[0].Points[0].XValue;
    double end = chart.Series[0].Points[chart.Series[0].Points.Count -1].XValue;
    double half = (start + end) / 2;
            
    chart.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
    chart.ChartAreas[0].AxisX2.CustomLabels.Add(start, end, "General Label", 0, LabelMarkStyle.Box);
    chart.ChartAreas[0].AxisX2.CustomLabels.Add(start, half, "Day 1", 1, LabelMarkStyle.LineSideMark);
    chart.ChartAreas[0].AxisX2.CustomLabels.Add(half, end, "Day 2", 1, LabelMarkStyle.LineSideMark);
