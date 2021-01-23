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
  
            //          
            // (*) INSERT ACTUAL EXECUTION CODE HERE, SEE BELOW
            //
            connection.Close();
        }
    }
