    var result = maindatatable.AsEnumerable()
        .Except(dt.AsEnumerable(), new CustomDataRowEqualityComparer());
    var dt2 = dt.Clone();
    foreach(DataRow mainRow in result)
    {
        var newRow = dt2.Rows.Add();
        foreach (DataColumn col in dt2.Columns)
            newRow[col] = mainRow[col.ColumnName];
    }
