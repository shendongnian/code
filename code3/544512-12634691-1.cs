    var dt3 = new DataTable();
    
    var columns = dt1.Columns.Cast<DataColumn>()
                      .Concat(dt2.Columns.Cast<DataColumn>());
    
    foreach (var column in columns)
    {
        dt3.Columns.Add(column.ColumnName, column.DataType);
    }
    
    //TODO Check if dt2 has more rows than dt1...
    for (int i = 0; i < dt1.Rows.Count; i++)
    {
        var row = dt3.NewRow();
        row.ItemArray = dt1.Rows[i].ItemArray
                           .Concat(dt2.Rows[i].ItemArray).ToArray();
    
        dt3.Rows.Add(row);
    }
