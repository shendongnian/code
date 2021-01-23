    Excel.Range chartRange;
    Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
    Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
    Excel.Chart chartPage = myChart.Chart;
    chartRange = xlWorkSheet.get_Range("A1", "d5");
    chartPage.SetSourceData(chartRange, misValue);
    chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
    //~~> From here this is the part which you want
    chartPage.ApplyLayout(6, Type.Missing);
    chartPage.Axes(Excel.XlAxisType.xlValue).AxisTitle.Select();
    chartPage.Axes(Excel.XlAxisType.xlValue).AxisTitle.Orientation = Excel.XlOrientation.xlHorizontal;
    //~~> 35 Deg angle
    for (int i = 1; i <= 35; i++)
    {
        chartPage.Axes(Excel.XlAxisType.xlValue).AxisTitle.Orientation = -i;
    }
