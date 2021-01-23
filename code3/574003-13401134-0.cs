    var data = new Object[] { "A", 1, 'B', 2.3 };
    DataTable t = new DataTable();
    // create all DataColumns
    for (int i = 0; i < data.Length; i++)
    {
        t.Columns.Add(new DataColumn("Column " + i, data[i].GetType()));
    }
    // add the row to the table
    t.Rows.Add(data);
