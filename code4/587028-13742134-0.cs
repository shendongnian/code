    //ExcelPackage is a class within the EPPlus DLL
    var p = new ExcelPackage();
    p.Workbook.Worksheets.Add("sheetName")
    var ws = p.Workbook.Worksheets.First();
    //Add the piechart
    var pieChart = ws.Drawings.AddChart("crtExtensionsSize", eChartType.PieExploded3D) as ExcelPieChart;
    
    //Set top left corner to row 1 column 2
    pieChart.SetPosition(1, 0, 2, 0);
    pieChart.SetSize(400, 400);
    pieChart.Series.Add(ExcelRange.GetAddress(4, 2, row-1, 2), ExcelRange.GetAddress(4, 1, row-1, 1));    
    pieChart.Title.Text = "Extension Size";
    
    //Set datalabels and remove the legend
    pieChart.DataLabel.ShowCategory = true;
    pieChart.DataLabel.ShowPercent = true;
    pieChart.DataLabel.ShowLeaderLines = true;
    pieChart.Legend.Remove();
