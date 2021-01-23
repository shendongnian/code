		DataTable dt = new DataTable();
		dt.Columns.Add("ID", typeof (int));
		dt.Columns.Add("AnotherID", typeof(int));
		dt.Columns.Add("Content", typeof(string));
		dt.PrimaryKey = new[] {dt.Columns["ID"]};
		// Add some data
		dt.Rows.Add(1, 10, "1");
		dt.Rows.Add(2, 11, "2");
		dt.Rows.Add(3, 12, "3");
		dt.Rows.Add(4, 13, "4");
		var index = dt.Rows.IndexOf(dt.Rows.Find(3));
		// index is 2
		
		Console.WriteLine(dt.Rows[index+1]);
		
