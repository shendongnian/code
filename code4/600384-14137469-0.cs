    using(var dbconn = new SqlConnection(connectionString))
    {
    	using (var dbcmd = new SqlCommand(storedProcedure, dbconn))
    	{
    		dbcmd.CommandType = CommandType.StoredProcedure;
    		dbcmd.Parameters.AddRange(sqlParameters.ToArray());
    		dbconn.Open();
    		return dbcmd.ExecuteNonQuery();
    	}
    }
