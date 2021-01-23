    using (var db = new testDataSet())
    {
    	using (testDataSetTableAdapters.UsersTableAdapter t = new testDataSetTableAdapters.UsersTableAdapter())
    	{
    		t.Fill(db.Users);
    		//One of the following two is enough
    		t.Connection.Dispose(); //THIS OR
    		t.Adapter.Dispose();    //THIS LINE MAKES THE DB FREE
    	}
    	Console.WriteLine((from x in db.Users select x.Username).Count());
    }
