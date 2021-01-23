    using (var connection = new SqlConnection(...))
    {
        connection.Open();
        using (var command = new SqlComand(...))
        {
            ...
        }
    }
