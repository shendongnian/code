    public void doExcel()
    {
    
        Excel.Application myExcelApplication = new Excel.Application();
        myExcelApplication.Visible = true; 
        myExcelApplication.ScreenUpdating = true;
        Excel.Workbook myExcelWorkbook = (Excel.Workbook) myExcelApplication.Workbooks.Add(System.Reflection.Missing.Value)); 
        Excel.Worksheet myExcelWorkSheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;
    
        for (int i = 0; i < myList.Count; i++)
        {
            myExcelWorkSheet.Cells[3, i] = String.Format("{0}", myList[i]);                
        }
        myExcelWorkbook.Close(true, "C:\\data.xls", System.Reflection.Missing.Value);
    }
