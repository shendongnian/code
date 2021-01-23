    public static DataTable Union(DataTable First, DataTable Second, string strReturnedTableName)
    {
        // Result table.
        DataTable table = new DataTable(strReturnedTableName);
        // Build new columns.
        DataColumn[] newcolumns = new DataColumn[First.Columns.Count];
        for (int i = 0; i < First.Columns.Count; i++)
            newcolumns[i] = new DataColumn(First.Columns[i].ColumnName, First.Columns[i].DataType);
        // Add new columns to result table.
        table.Columns.AddRange(newcolumns);
        table.BeginLoadData();
        // Load data from first table.
        foreach (DataRow row in First.Rows)
            table.LoadDataRow(row.ItemArray, true);
        // Load data from second table.
        foreach (DataRow row in Second.Rows)
            table.LoadDataRow(row.ItemArray, true);
        table.EndLoadData();
        return table;
    }
    
