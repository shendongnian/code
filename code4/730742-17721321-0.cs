    DataTable dt = new DataTable);
    using (var myConnection = new SqlConnection(connectionstring))
    {
    	using (var myCommand = new SqlCommand("Getdata", myConnection))
    	{
    		myCommand.CommandType = CommandType.StoredProcedure;
    		SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(myCommand);
    		mySqlDataAdapter.Fill(dt);
    	}
    }
