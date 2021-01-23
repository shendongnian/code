    public static T ExecuteScalar<T>(string query, 
                                 SqlConnection connection, 
                                 params SqlParameter[] parameters) 
    {
        SqlCommand command = CreateCommand(query, connection, parameters);
        var result = command.ExecuteScalar();
        if (result is T) return (T)result;
        return default(T);
    }
