    foreach(DataRow row in table.Rows)
    {
     foreach(DataColumn column in table.Columns)
     {
      sw.WriteLine(row[column]);
     }
    }
