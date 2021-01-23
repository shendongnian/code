    ChartSeriesEx series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillTypeEx.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.FromArgb(32, 202, 250);
    series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 40));
    series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 64));
    series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 50));
    series.Values.Add(fact.GetCell(defaultWorksheetIndex, 4, 1, 1));
