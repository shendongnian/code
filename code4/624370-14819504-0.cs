    Excel.ChartObjects xlChart = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
    Excel.ChartObject myChart = (Excel.ChartObject)xlChart.Add(1420, 660, 320, 180);
    Excel.Chart chartPage = myChart.Chart;
    chartPage.ChartType = Excel.XlChartType.xlLineMarkers;
    chartPage.HasTitle = true;
    chartPage.ChartTitle.Text = "Title Text";
    chartPage.HasLegend = false;
    
    var yAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue,Excel.XlAxisGroup.xlPrimary);
    yAxis.HasTitle = true;
    yAxis.AxisTitle.Text = "Y-Axis Title text";
    yAxis.MaximumScale = 20;
    yAxis.AxisTitle.Orientation = Excel.XlOrientation.xlUpward;
    
    Excel.Range Data_Range = xlWorkSheet.get_Range("A10", "C10");//Data to be plotted in chart
    Excel.Range XVal_Range = xlWorkSheet.get_Range("A1", "C1");//Catagory Names I want on X-Axis as range
    
    Excel.SeriesCollection oSeriesCollection = (Excel.SeriesCollection)myChart.Chart.SeriesCollection(misValue);
    Excel.Series Data = oSeriesCollection.NewSeries();
    Data.Values = Data_Range;
    Data.Name = "Plot Data";
    
    Excel.Axis xAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
    xAxis.CategoryNames = XVal_Range;
