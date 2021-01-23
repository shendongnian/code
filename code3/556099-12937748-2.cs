    public static void ReorderTable(ref DataTable table, params String[] columns)
    {
        if (columns.Length != table.Columns.Count)
            throw new ArgumentException("Count of columns must be equal to table.Column.Count", "columns");
        for (int i = 0; i < columns.Length; i++)
        {
            table.Columns[columns[i]].SetOrdinal(i);
        }
    }
