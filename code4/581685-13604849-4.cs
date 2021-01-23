    public static DataTable MergeOnRowIndex(DataTable table1, DataTable table2)
    {
        var table2Rows = table2.AsEnumerable();
        var data = table1.AsEnumerable()
            .Select((r, i) => new
            {
                Row1 = r,
                Row2 = table2Rows.ElementAtOrDefault(i)
            });
        DataTable table3 = new DataTable();
        foreach (DataColumn col in table1.Columns)
        {
            table3.Columns.Add(col.ColumnName, col.DataType);
        }
        foreach(DataColumn col in table2.Columns)
            if(!table3.Columns.Contains(col.ColumnName))
                table3.Columns.Add(col.ColumnName, col.DataType);
        if(data.Any())
        {
            foreach(var x in data)
            {
                var newRow = table3.Rows.Add();
                for (int i = 0; i < table1.Columns.Count; i++)
                {
                    newRow[i] = x.Row1.ItemArray[i];
                }
                if (x.Row2 != null)
                {
                    for (int i = table1.Columns.Count; i < table3.Columns.Count; i++)
                    {
                        DataColumn currentColumn = table3.Columns[i];
                        newRow[currentColumn.ColumnName] = x.Row2[currentColumn.ColumnName];
                    }
                }
            }
        }
        return table3;
    }
