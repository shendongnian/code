    using (var connection = new SqlConnection(...))
    using (var command = new SqlCommand(..., connection))
    {
        connection.Open();
        ...
        using (var reader = command.ExecuteReader())
        {
            return reader.Read() ? (int) reader[0] : 0;
        }
    }
