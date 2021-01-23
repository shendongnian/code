    Series s = pieChart.Series.Add("pie");
    s.ChartType = SeriesChartType.Pie;
    s.IsValueShownAsLabel = true;
    for (int colindex = 1; colindex < regionVolumeTable.Columns.Count; colindex++)
    {
        s.Points.AddXY(regionVolumeTable.Columns[colindex].HeaderText,
                       regionVolumeTable[colindex, 0].Value);
    }
