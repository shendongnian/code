    public static DataTable GetDataTableFromRange(ExcelRange range)
    {
      DataTable tbl = new DataTable();
      tbl.Columns.Add("Column1");
      tbl.Columns.Add("Column2");
      tbl.Columns.Add("Column3");
    
      int dataTableColumn = 0;
      DataRow newRow = null;
      int currRow = -1;
      foreach (var item in range)
      {
        if (currRow != item.Start.Row)
        {
          newRow = tbl.NewRow();
          tbl.Rows.Add(newRow);
          dataTableColumn = 0;
          currRow = item.Start.Row;
        }
        newRow[dataTableColumn] = item.Value.ToString();
        dataTableColumn++;
      }
      return tbl;
    }
