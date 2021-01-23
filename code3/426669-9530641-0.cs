    DataTable dt = new DataTable();
    dt.Columns.Add("DateOfBirth", typeof(DateTime));
    dt.Rows.Add(new object[] { new DateTime(1981, 10, 29) });
    dt.Rows.Add(new object[] { new DateTime(1984, 8, 12) });
    dt.Rows.Add(new object[] { new DateTime(1982, 9, 7) });
    bindingSource1.DataSource = dt;
    dataGridView1.DataSource = bindingSource1;
    dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;
