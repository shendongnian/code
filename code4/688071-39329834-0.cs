	// Create an empty datatable
	DataTable empty = new DataTable();
	empty.Columns.Add("Name", typeof(string));
	empty.Columns.Add("Color", typeof(myEnum));
	empty.Columns.Add("Count", typeof(int));
	...
	// Clear datagridview
	dgv.DataSource = empty;
