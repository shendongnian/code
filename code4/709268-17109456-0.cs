    using(OleDbConnection c = new OleDbConnection(con))
    {
    	c.Open();
    	string selectString = "SELECT * FROM [Sheet1$RANGE_NAMED]";
    	using(OleDbCommand cmd1 = new OleDbCommand(selectString))
    	{
              cmd1.Connection = c;
    	    var result = cmd1.ExecuteReader();
    	    while(result.Read())
    	    {
                  Console.WriteLine(result[0].ToString());
    	    }
    	}
    }
