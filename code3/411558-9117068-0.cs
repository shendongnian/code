    using (SqlConnection sqlConn = new SqlConnection(yourConnStr))
    using (SqlCommand sqlCmd = new SqlCommand(yourProcedureName, sqlConn))
    {
    	sqlConn.Open();
    	sqlCmd.CommandType = CommandType.StoredProcedure;
    	SqlCommandBuilder.DeriveParameters(sqlCmd);
    	// now you can check parameters in sqlCmd.Parameters
    }
