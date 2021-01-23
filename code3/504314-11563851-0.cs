    foreach (DataRow row in t1.Rows)
    {
        var r = t2.Rows.Add();
        foreach (DataColumn col in t2.Columns)
        {
            r[col.ColumnName] = row[col.ColumnName];
        }
    }
