    public static T ExecuteScalar<T>(
        Func<object, T> conversionFunctor,
        string query, 
        SqlConnection connection, 
        params SqlParameter[] parameters) where T : new()
    {
        // Create SqlCommand
        SqlCommand command = CreateCommand(query, connection, parameters);
    
        // Execute command using ExecuteScalar
        object result = command.ExecuteScalar();
    
        // Return value as expected type
        if (result == null || result is DBNull) 
            return default(T);
        return conversionFunctor(result);
    }
