    public void CreateExcelDocFromDatatable(DataTable dataTable)
    {
        object misValue = System.Reflection.Missing.Value;
        Excel.Application xlApp = new Excel.ApplicationClass();
        Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
        Excel.Worksheet xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        
        int iCol = 0;
        foreach (DataColumn c in dataTable.Columns)
        {
            iCol++;
            xlWorkSheet1.Cells[1, iCol] = c.ColumnName;
        }
        int iRow = 0;
        foreach (DataRow r in dataTable.Rows)
        {
            iRow++;
            iCol = 0;
            foreach (sd.DataColumn c in mdtOutput.Columns)
            {
                string cellData = r[c.ColumnName].ToString();
                iCol++;
                xlWorkSheet1.Cells[iRow + 1, iCol] = r[c.ColumnName];
            }
        }
    
        xlWorkSheet1.Activate();
        var range = xlWorkSheet1.get_Range("2:2",misValue);
        range.Select();
        xlApp.ActiveWindow.FreezePanes = true;
        range = xlWorkSheet1.get_Range("1:1", misValue);
        range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
        
        mXlWorkBook.SaveAs(outputFilePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        xlApp.Visible = true;
        xlWorkSheet1.Activate();
    }
  
    private void CreateExcelCharts()
    {
        object misValue = System.Reflection.Missing.Value;
        Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
        Excel.Worksheet chartsSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
        chartsSheet.DisplayRightToLeft = false;
        chartsSheet.Name = "Charts";
        Excel.ChartObjects chartObjs = (Excel.ChartObjects)chartsSheet.ChartObjects(Type.Missing);
        Excel.ChartObject chartObj = chartObjs.Add(200, 40, 300, 300);
        Excel.Chart xlChart = chartObj.Chart;
        Excel.Range range = chartsSheet.get_Range("B2", "C7");
        xlChart.SetSourceData(range, misValue);
        xlChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xl3DPie;
        mXlWorkBook.Save();
    }
