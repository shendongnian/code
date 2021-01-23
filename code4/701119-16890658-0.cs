	var table = new DataTable();
	table.Columns.Add("Name", typeof(string));
	table.Columns.Add("Count", typeof(int));
	
	table.Rows.Add("A", 5);
	table.Rows.Add("B", 7);
	table.Rows.Add("C", 1);
	table.Rows.Add("D", 8);
	table.Rows.Add("E", 9);
	table.Rows.Add("F", 6);
	table.Rows.Add("G", 3);
	table.Rows.Add("H", 2);
	table.Rows.Add("I", 4);
	
	var sorted = table.Rows.Cast<DataRow>()
		.OrderByDescending(row => row[1]);
	
	// if you are using LINQPad you can test this using the following line:
	sorted.Dump();
