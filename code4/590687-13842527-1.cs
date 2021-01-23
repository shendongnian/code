    public static void AddNullable(this SqlParameterCollection parameters, 
                                string paramName, object newParameter)
    {
        parameters.AddWithValue(paramName, newParameter ?? DBNull.Value);
    }
    
    cmd_insert.Parameters.AddNullable("@value1", record.commRate);
