	public static String Trimsiblings(String ppl) {
		var table=GetSiblingTable();
		var pids=ppl.Split(',');
		return
			String.Join(", ", (
				from id in pids.Select(x => int.Parse(x))
				where (
					from row in table.AsEnumerable()
					select
						from DataColumn column in table.Columns
						let data=row[column.ColumnName]
						where DBNull.Value!=data
						select int.Parse((String)data)
					).All(x => false==x.Contains(id)||x.First()==id)
				select id.ToString()).ToArray()
				);
	}
<!--->
	// emulation of getting table from database
	public static DataTable GetSiblingTable() {
		var dt=new DataTable();
		// define field1, ..., fieldn
		for(int n=3, i=1+n; i-->1; dt.Columns.Add("field"+i))
			;
		dt.Rows.Add(new object[] { 1, 2, 3 });
		dt.Rows.Add(new object[] { 8, 9 });
		return dt;
	}
	public static void TestMethod() {
		Console.WriteLine("{0}", Trimsiblings("1, 2, 3, 4, 5, 6, 7, 8, 9, 10"));
	}
