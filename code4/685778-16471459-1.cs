    public static SqlDataReader GetSql(string businessUnit, string taskId)
    {
    	const string connstring = "Connection string";
    	SqlConnection conn = null;
    	SqlCommand command = null;
    	SqlDataReader reader = null;
    	try
    	{
    		conn = new SqlConnection(connstring);
    		command = new SqlCommand();
    		command.Connection = conn;
    		command.CommandType = CommandType.Text;
    		command.CommandText = "SELECT * FROM Audits WHERE BusinessUnit = @BU AND TaskID = @TID";
    		command.Parameters.AddWithValue("@BU", businessUnit);
    		command.Parameters.AddWithValue("@TID", taskId);
    		conn.Open();
    		reader = command.ExecuteReader(CommandBehavior.CloseConnection);
    		conn = null;
    		return reader;
    	}
    	catch (Exception ex)
    	{
    		return null;
    	}
    	finally
    	{
    		if (conn != null) conn.Dispose();
    		if (command != null) command.Dispose();
    	}
    }
