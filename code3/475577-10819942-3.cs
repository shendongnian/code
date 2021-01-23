    foreach (DataColumn dCol in tbl1.Columns)
    {
        dataGridView1.Columns.Add(dCol.ColumnName, dCol.Caption);
    }
    foreach (var s in res1)
    {
        foreach (var item in res1)
        {
            dataGridView1.Rows.Add(item.ItemArray);
        }
    }
