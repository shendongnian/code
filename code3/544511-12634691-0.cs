    var dt3 = new DataTable();
    
    var columns = dt1.Columns.Cast<DataColumn>()
                      .Concat(dt2.Columns.Cast<DataColumn>());
    
    foreach (var column in columns)
    {
        dt3.Columns.Add(column.ColumnName, column.DataType);
    }
    
    for (int i = 0; i < dt1.Rows.Count; i++)
    {
        var row = dt3.NewRow();
        row.ItemArray = dt1.Rows[i].ItemArray
                           .Concat(dt2.Rows[i].ItemArray).ToArray();
    
        dt3.Rows.Add(row);
    }
