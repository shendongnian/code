    using(SqlConnection connection = GetConnection())
    {
        if(connection.IsAvailable())
        {
            // Success
        }
    }
