    string tableName = "ABCDFEGH";
    string date = "05/10/2012 13:00:30";
    String query =  "SELECT  * FROM  " + tableName + " WHERE   STR_TO_DATE(`capTime`, '%m/%d/%Y %H:%i:%s:%x') >  STR_TO_DATE(@dateHere, '%c/%d/%Y %H:%i:%s')";
    using (MySqlConnection connection = new MySqlConnection("connectionStringHere"))
    {
    	using (MySqlCommand command = new MySqlCommand())
    	{
    		command.Connection = connection;
    		command.CommandType = CommandType.Text;
    		command.CommandText = query;
    		command.Parameters.AddwithValue("@dateHere",date)
    		MySqlDataReader dataReader = null;
    		try
    		{
    			dataReader = cmd.ExecuteReader();
    		}
    		catch(MySqlException e)
    		{
    			// do something here
    			// don't suppress the error
    		}
    	}
    }
