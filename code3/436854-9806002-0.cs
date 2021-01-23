    public static MemoryStream DataTableToExcelXlsx(DataTable table, string sheetName)
    {
      MemoryStream Result = new MemoryStream();
      ExcelPackage pack = new ExcelPackage();
      ExcelWorksheet ws = pack.Workbook.Worksheets.Add(sheetName);
    
      int col = 1;
      int row = 1;
      foreach (DataRow rw in table.Rows)
      {
        foreach (DataColumn cl in table.Columns)
        {
          if (rw[cl.ColumnName] != DBNull.Value)
            ws.Cells[row, col].Value = rw[cl.ColumnName].ToString();
          col++;
        }
        row++;
        col = 1;
      }
    
      pack.SaveAs(Result);
      return Result;
    }
     
