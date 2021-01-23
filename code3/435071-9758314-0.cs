    var tbl = dset.Tables["Profile"]:
    var swappedTable = new DataTable();
    for (int i = 0; i <= tbl.Rows.Count; i++)
    {
        swappedTable.Columns.Add(Convert.ToString(i));
    }
    for (int col = 0; col < tbl.Columns.Count; col++)
    {
        var r = swappedTable.NewRow();
        r[0] = tbl.Columns[col].ToString();
        for (int j = 1; j <= tbl.Rows.Count; j++)
            r[j] = tbl.Rows[j - 1][col];
        swappedTable.Rows.Add(r);
    }
    dataGridView1.DataSource = swappedTable;
