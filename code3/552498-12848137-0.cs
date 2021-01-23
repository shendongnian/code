    static private T GetDataX<T>(SqlParameterHash parameters, string sql, string connectionString, Action<T, SqlDataAdapter> fillAction, CommandType commandType = CommandType.StoredProcedure) 
        where T : System.ComponentModel.MarshalByValueComponent, new()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
    
        SqlDataAdapter da = new SqlDataAdapter(sql, connection);
        da.SelectCommand.CommandType = commandType;
        da.SelectCommand.CommandTimeout = 0;
    
        foreach (SqlParameter Parameter in parameters)
        { da.SelectCommand.Parameters.Add(Parameter); }
    
        T container = new T();
        fillAction(container, da);
        da.SelectCommand.Parameters.Clear();
        return container;
    }
