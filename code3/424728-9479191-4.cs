    string spName = "stored_proc_name";
    string idParameterValue = "someId";
    
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        using (SqlCommand command = new SqlCommand(spName, connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Id", idParameterValue));
            connection.Open();
    
            IDbDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
  
            // (*) Put here a code block of the actual SP execution logic
            // There are dufferent ways of SP execution and it depends on
            // return result set type, see below
        }
    }
