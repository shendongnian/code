    DataTable table = new DataTable();
    foreach (var col in lst[0].Keys)
    {
         table.Columns.Add(col, typeof(string));
    }
    foreach (var dict in lst)
    {
         var row = table.NewRow();
         foreach (var data in dic)
         {
             row[data.Key] = data.Value;
         }
         table.Rows.Add(row);
    }
