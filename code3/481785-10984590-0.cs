	private void SampleSolution(DataTable dt1, DataTable dt2)
	{
		//If you have primary keys:
		var results = from table1 in dt1.AsEnumerable()
						join table2 in dt2.AsEnumerable() on table1.Field<int>("id") equals table2.Field<int>("id")
						where table1.Field<int>("ColumnA") != table2.Field<int>("ColumnA") || table1.Field<int>("ColumnB") != table2.Field<int>("ColumnB") || table1.Field<String>("ColumnC") != table2.Field<String>("ColumnC")
						select table1;
		//This will give you the rows in dt1 which do not match the rows in dt2.  You will need to expand the where clause to include all your columns.
		//If you do not have primarry keys then you will need to match up each column and then find the missing.
		var matched = from table1 in dt1.AsEnumerable()
						join table2 in dt2.AsEnumerable() on table1.Field<int>("ColumnA") equals table2.Field<int>("ColumnA")
						where table1.Field<int>("ColumnB") == table2.Field<int>("ColumnB") || table1.Field<string>("ColumnC") == table2.Field<string>("ColumnC") || table1.Field<object>("ColumnD") == table2.Field<object>("ColumnD")
						select table1;
		var missing = from table1 in dt1.AsEnumerable()
						where !matched.Contains(table1)
						select table1;
		//This should give you the rows which do not have a match.  You will need to expand the where clause to include all your columns.
	}
