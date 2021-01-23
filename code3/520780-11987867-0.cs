	var dt = new DataTable();
	dt.Columns.Add(new DataColumn("Time", typeof(DateTime)));
	dt.Rows.Add(new DateTime(2000, 12, 31, 12, 0, 0));
	dt.Rows.Add(new DateTime(2000, 12, 31, 12, 0, 0));
	dt.Rows.Add(new DateTime(2000, 12, 31, 12, 0, 1));
	dt.Rows.Add(new DateTime(2000, 12, 31, 12, 0, 2));
	dt.Rows.Add(new DateTime(2000, 12, 31, 12, 4, 2));
	dt.Rows.Add(new DateTime(2000, 12, 31, 12, 5, 5));
	dt.Rows.Add(new DateTime(2000, 12, 31, 12, 5, 2));
