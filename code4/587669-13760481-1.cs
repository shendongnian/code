	System.Data.DataTable table = new System.Data.DataTable();
	for (int i = 1; i <= 11; i++)
		table.Columns.Add("col" + i.ToString());
	for (int i = 0; i < 100; i++)
	{
		System.Data.DataRow row = table.NewRow();
		for (int j = 0; j < 11; j++)
			row[j] = i.ToString() + ", " + j.ToString();
		table.Rows.Add(row);
	}
	System.Data.DataView view = new System.Data.DataView(table);
	System.Data.DataTable selected = view.ToTable("Selected", false, "col1", "col2", "col6", "col7", "col3");
