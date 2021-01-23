    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string lsSql = string.Empty;
        foreach (var commandString in sqlCommandList)
        {
	        lsSql = lsSql + commandString + " ; " + Environment.NewLine;
        }
        connection.Open();
        SqlCommand command = new SqlCommand(lsSql, connection);
        command.ExecuteNonQuery();
    }
