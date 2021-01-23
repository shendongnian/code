    using (var connection = new SqlConnection(...))
    {
        connection.Open();
        using (var command = new SqlCommand(query, connection))
        {
            int count = (int) command.ExecuteScalar();
            // Now use the count
        }
    }
