        private void DrawFractionChart(Excel.Worksheet activeSheet, Excel.ChartObjects xlCharts, Excel.Range xRange, Excel.Range yRange)
        {
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(200, 500, 200, 100);
            Excel.Chart chartPage = myChart.Chart;
            Excel.SeriesCollection seriesCollection = chartPage.SeriesCollection();
            Excel.Series series1 = seriesCollection.NewSeries();
            series1.XValues = activeSheet.Range["E1", "E3"];
            series1.Values = activeSheet.Range["F1", "F3"];
            
            chartPage.ChartType = Excel.XlChartType.xlDoughnut;
            Excel.Axis axis = chartPage.Axes(Excel.XlAxisType.xlValue, Microsoft.Office.Interop.Excel.XlAxisGroup.xlPrimary) as Excel.Axis;
            series1.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowPercent, true, true, false, true, true, true, true);
        }
