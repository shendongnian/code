    using(SqlConnection conn = new SqlConnection(CONNECTION_STRING))
    {
        conn.Open();
        SqlCommand command = conn.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
    
        // Add all of your input parameters....
    
        SqlParameter pID = command.Parameters.Add
                     ("@ID",SqlDbType.Int);
        pID.Direction = ParameterDirection.Output;
        command.CommandText = "YourInsertProc";
        command.ExecuteNonQuery();
        // After executing the stored procedure, the SCOPE_IDENTITY() value 
        // could be read from the parameter value.
        int result = Convert.ToInt32(pID.Value);    
    }
