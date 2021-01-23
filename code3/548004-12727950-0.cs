    Excel.Application application = new Excel.Application();
    Excel.Workbook workbook = application.Workbooks.Open(@"C:\Whatever.xlsx");
    Excel.Worksheet worksheet = workbook.ActiveSheet;
    
    Excel.Range usedRange = worksheet.UsedRange;
    
    Excel.Range rows = usedRange.Rows;
    
    foreach (Excel.Range row in rows)
    {
        Excel.Range firstCell = row.Cells[1];
    
        string firstCellValue = firstCell.Value;
    
        if (!string.IsNullOrEmpty(firstCellValue))
        {
            row.Interior.Color = System.Drawing.Color.Red;
        }
    }
    
    workbook.Save();
    workbook.Close();
    
    application.Quit();
    
    Marshal.ReleaseComObject(application);
