    // your command initialization code here
    // ...
    DataSet ds = new DataSet();
    DataTable t;
    using (DbDataReader reader = command.ExecuteReader())
    {
	  while (!reader.IsClosed)
	  {
	    t = new DataTable();
		t.Load(rs);
		ds.Tables.Add(t);
	  }
    }
