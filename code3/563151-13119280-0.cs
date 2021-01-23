	using (var connection = new SqlConnection(connectionString))
    using (var command = new SqlCommand("SELECT Name, Is_Nullable FROM sys.columns WHERE [Object_ID] = OBJECT_ID(@TableName)", connection))
    {
        connection.Open();
        command.Parameters.Add("@TableName", SqlDbType.VarChar).Value = tableName;
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine("Name: {0}; Allows Null: {1}", reader.GetString(0), reader.GetBoolean(1));
            }
        }
    }
