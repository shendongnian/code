    public void Try(string conStr, string storedProcedure) {
    	using (var sqlCon = new SqlConnection(conStr)) {
    		// create command, also a local variable
    		var sqlCmd = new SqlCommand();
    		
    		// set connection
    		sqlCmd.Connection = sqlCon
    
    		//add command type
    		sqlCmd.CommandType = CommandType.StoredProcedure;
    
    		// add the stored procedure name
    		sqlCmd.CommandText = storedProcedure;
    
    		//Open connection
    		sqlCon.Open();
    
    		// Execute transaction
    		sqlCmd.ExecuteNonQuery();
    	}
    }
