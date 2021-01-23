    public static DataTable ReorderTable(DataTable table, params String[] columns)
    {
        DataTable table2 = table.Clone();
        for (int i = 0; i < columns.Length; i++)
        {
            table2.Columns[columns[i]].SetOrdinal(i);
        }
        foreach (DataRow row in table.Rows)
        { 
            DataRow newRow = table2.Rows.Add();
            foreach(DataColumn col in table2.Columns)
            {
                newRow[col.ColumnName] = row[col.ColumnName];
            }
        }
        return table2;
    }
