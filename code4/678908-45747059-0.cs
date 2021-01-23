    Excel.Application xlApp;
    Excel.Workbook xlWorkBook;
    Excel.Worksheet xlWorkSheet;
    object misValue = System.Reflection.Missing.Value;
    xlApp = new Excel.ApplicationClass();
    xlWorkBook = xlApp.Workbooks.Add(misValue);
    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    int currentLine = 1;
    foreach (int currentKey in currentLogFile.Keys)
    {
          xlWorkSheet.Cells[currentLine, 1] = currentKey;
          xlWorkSheet.Cells[currentLine, 2] = currentLogFile[currentKey];
          currentLine++; 
    }
    Excel.Range chartRange;
    Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
    Excel.Chart chartPage = myChart.Chart;
    chartRange = xlWorkSheet.get_Range("A1", "B10");
    chartPage.SetSourceData(chartRange, misValue);
    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;
    
    //Rotate 35 degrees.
    chartPage.Axes(Excel.XlAxisType.xlCategory).TickLabels.Orientation = 35;
    chartPage.Axes(Excel.XlAxisType.xlValue).TickLabels.Orientation = 35;
    chartPage.ApplyLayout(6, Type.Missing);
    xlWorkBook.SaveAs(excelOutputFile, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, 
    Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
    xlWorkBook.Close(true, misValue, misValue);
    xlApp.Quit();
