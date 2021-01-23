    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = commandText;
    
        command.Parameters.AddWithValue("@paramName", paramValue);
        // or
        // command.Parameters.Add("@paramName", SqlDbType.Type).Value = paramValue;
        // ...
    
        connection.Open();
        command.ExecuteNonQuery();
    }
