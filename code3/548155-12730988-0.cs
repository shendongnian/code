    public T GetScalarValue<T>(string sql) where T : struct
    {
        string connectionString = "MY_SQL_SERVER_CONNECTION_STRING";
    
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(sql, connection))
        {
            connection.Open();
            Object obj = command.ExecuteScalar();
    
            return (obj == null) ? (T)obj : default(T);
        }
    }
