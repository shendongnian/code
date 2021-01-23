    public static bool WriteToDatabase(
        string sql,
        CommandType commandType, 
        string[] paramNames,    
        object[] paramValues,    
        out string errorText)    
    {
        ...
        for (int i = 0; i < paramNames.Length; i++) {
            command.Parameters.AddWithValue(paramNames[i], paramValues[i]);
        }
        ...
    }
