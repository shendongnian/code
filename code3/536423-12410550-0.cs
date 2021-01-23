    using(SqlConnection conn = new SqlConnection(CONNECTION_STRING))
    {
        conn.Open();
        SqlCommand command = conn.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
    
        // Add all of your input parameters....
    
        SqlParameter parameter = command.Parameters.Add
                     ("@ID",SqlDbType.Integer);
        parameter.Direction = ParameterDirection.Output;
        command.CommandText = "YourInsertProc";
        command.ExecuteNonQuery();
        int result = Convert.ToInt32(parameter.Value);    
    }
