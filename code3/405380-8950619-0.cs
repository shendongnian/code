    public SqlCommand PrepareSPCommand(string storedProcName, SqlParameter[] parameters, string connectionString){
        SqlCommand command = new SqlCommand(storedProcName,new SqlConnection(connectionString));
        command.CommandType=CommandType.StoredProcedure;
        command.Parameters.AddRange(parameters);
    
        return command;
    }
