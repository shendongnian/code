    IWorkbook workbook;
    using (FileStream stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read))
    {
        workbook = new HSSFWorkbook(stream);
    }
    
    ISheet sheet = workbook.GetSheetAt(0);
    DataTable dt = new DataTable(sheet.SheetName);
    
    // write header row
    IRow headerRow = sheet.GetRow(0);
    foreach (ICell headerCell in headerRow)
    {
        dt.Columns.Add(headerCell.ToString());
    }
    
    // write the rest
    int rowIndex = 0;
    foreach (IRow row in sheet)
    {
         // skip header row
         if (rowIndex++ == 0) continue;
    
         // add row into datatable
         var cells = new List<ICell>();
         for (int i = 0; i < dt.Columns.Count; i++)
         {
              cells.Add(row.GetCell(i, MissingCellPolicy.CREATE_NULL_AS_BLANK));
         }
         
         // Columns formatted as DateTime will be printed as '01-Jul-2005', 
         // which can be converted to datetime in the SQL server.
         // select cast('01-Jul-2005' as DateTime).
         // In SQL Server we can convert DateTime to whatever string we want, for example
         // select convert(nvarchar(255), cast('01-Jul-2005' as datetime), 112) will print '20050701'.
         // http://www.sqlusa.com/bestpractices/datetimeconversion/
         dt.Rows.Add(cells.Select(c => c.ToString()).ToArray());
    
         // Datetimes also can be reformatted directly like this :
         // dt.Rows.Add(cells.Select(c =>
         //    c.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(c) 
         //        ? c.DateCellValue.ToString("yyyyMMdd") 
         //        : c.ToString()
         // ).ToArray());
    }
    
    //return dt;
