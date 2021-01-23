    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = "INSERT INTO tableName (County) VALUES (@County)";
    
        command.Parameters.AddWithValue("@County", selectedText);
    
        connection.Open();
        command.ExecuteNonQuery();
    }
