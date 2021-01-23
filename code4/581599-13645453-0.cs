    public static void addBarChart()
    {
        PresentationEx pres = new PresentationEx();
        ChartEx chart = pres.Slides[0].Shapes.AddChart(ChartTypeEx.ClusteredColumn, 20, 20, 500, 400);
        //Setting values of Y-axis or Value axis
        chart.ValueAxis.IsAutomaticMaxValue = false;
        chart.ValueAxis.IsAutomaticMinValue = false;
        chart.ValueAxis.CrossType = CrossesTypeEx.Custom;
        chart.ValueAxis.MinValue = 0;
        chart.ValueAxis.MaxValue = 400;
        chart.ValueAxis.CrossAt = 100f;
        chart.ChartData.Series.Clear();
        int defaultWorksheetIndex = 0;
        //Getting the chart data worksheet
        ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;
        //Adding new series
        int id=chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        ChartSeriesEx series = chart.ChartData.Series[id];
        //Now populating series data
        series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 30));
        series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 150));
        series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 320));
        series.Values.Add(fact.GetCell(defaultWorksheetIndex, 4, 1, 80));
        series.Format.Fill.FillType = FillTypeEx.Solid;
        series.Format.Fill.SolidFillColor.Color = Color.Red;
        series.IsColorVaried = false;
        pres.Write("D:\\Aspose Data\\SampleChart.pptx");
 
    }
