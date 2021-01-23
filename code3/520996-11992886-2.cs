    Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
    Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
    Excel.Chart chartPage = myChart.Chart;
    chartRange = xlWorkSheet.get_Range("A1", "d5");
    chartPage.SetSourceData(chartRange, misValue);
    chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
    chartPage.ApplyLayout(6, Type.Missing);
    
    chartPage.Axes(Excel.XlAxisType.xlCategory).Select();
    chartPage.Axes(Excel.XlAxisType.xlCategory).TickLabels.Orientation = 35;
