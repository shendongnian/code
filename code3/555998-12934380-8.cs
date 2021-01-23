    public DataTable RemoveDuplicateRows(DataTable dTable, String[] colNames)
    {
        var hTable = new Dictionary<object[], DataRow>(new ObjectArrayComparer());
        foreach (DataRow drow in dTable.Rows)
        {
            Object[] objects = new Object[colNames.Length];
            for (int c = 0; c < colNames.Length; c++)
                objects[c] = drow[colNames[c]];
            if (!hTable.ContainsKey(objects))
                hTable.Add(objects, drow);
        }
        // create a clone with the same columns and import all distinct rows
        DataTable clone = dTable.Clone();
        foreach (var kv in hTable)
            clone.ImportRow(kv.Value);
        return clone;
    }
