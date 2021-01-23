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
	public static String Trimsiblings(String ppl) {
		var table=GetSiblingTable();
		var pids=ppl.Split(',');
		return
			String.Join(", ", (
				from id in pids.Select(x => int.Parse(x))
				let query=
					from row in table.AsEnumerable()
					from DataColumn column in table.Columns
					let value=row[column.ColumnName]
					where DBNull.Value!=value
					select int.Parse((String)value)
				where false==query.Contains(id)||query.First()==id
				select id.ToString()).ToArray()
				);
	}
