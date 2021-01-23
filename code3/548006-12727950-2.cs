    Excel.Application application = new Excel.Application();
    Excel.Workbook workbook = application.Workbooks.Open(@"C:\Test\Whatever.xlsx");
    Excel.Worksheet worksheet = workbook.ActiveSheet;
    
    Excel.Range usedRange = worksheet.UsedRange;
    
    Excel.Range rows = usedRange.Rows;
    
    int count = 0;
    
    foreach (Excel.Range row in rows)
    {
        if (count > 0)
        {
            Excel.Range firstCell = row.Cells[1];
    
            string firstCellValue = firstCell.Value as String;
    
            if (!string.IsNullOrEmpty(firstCellValue))
            {
                row.Interior.Color = System.Drawing.Color.Red;
            }
        }
    
        count++;
    }
    
    workbook.Save();
    workbook.Close();
    
    application.Quit();
    
    Marshal.ReleaseComObject(application);
