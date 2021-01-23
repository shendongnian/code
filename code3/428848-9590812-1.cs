    private int ExecuteNonQueryWithOutput(string procedureName, SqlParameter[] parameters)
    {
    	int retval = 0;
    	using (SqlConnection conn = new SqlConnection("connection string here"))
    	using (SqlCommand command = this.GenerateCommand(procedureName, parameters)) {
    	    connection.Open();
    	    command.ExecuteNonQuery();
    	    retval = (int)command.Parameters[OUTPUT].Value;
    	}
    	return retval;
    }
