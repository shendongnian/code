    public static DataTable MergeTablesByIndex(DataTable t1, DataTable t2)
    {
        if (t1 == null || t2 == null) throw new ArgumentNullException("t1 or t2", "Both tables must not be null");
        DataTable t3 = new DataTable();
        var mergedColumns = t1.Columns.Cast<DataColumn>()
            .Select(c => new DataColumn { ColumnName = c.ColumnName, DataType = c.DataType })
            .Concat(t2.Columns.Cast<DataColumn>()
            .Select(c => new DataColumn { ColumnName = c.ColumnName, DataType = c.DataType }));
        t3.Columns.AddRange(mergedColumns.ToArray());
        var mergedRows = t1.AsEnumerable().Zip(t2.AsEnumerable(),
            (r1, r2) => r1.ItemArray.Concat(r2.ItemArray).ToArray());
        foreach (object[] rowFields in mergedRows)
            t3.Rows.Add(rowFields);
        return t3;
    }
