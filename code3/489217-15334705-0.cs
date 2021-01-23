    Excel.Range range = workSheet.get_Range("A1", "D4");
    
    int totalRows = range.Rows.Count;
    int totalColumns = range.Columns.Count;
    for (int rowCounter = 1; rowCounter <= totalRows; rowCounter++)
    {
      for (int colCounter = 1; colCounter <= totalColumns; colCounter++)
      {
         var cellVal = workSheet.Cells[rowCounter, colCounter];
         var val = cellVal.Text;
      }
    }
