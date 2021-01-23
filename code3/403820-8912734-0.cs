     foreach (System.Data.DataRow row in table.Rows)
    {
      foreach (System.Data.DataColumn col in table.Columns)
      {
        Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
      }     
    }
