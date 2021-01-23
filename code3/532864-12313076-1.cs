    using(var connection = new SqlConnection(ConnectionString))
    {
        connection.Open();
        using(var command = new SqlCommand("insert_sproc",connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("someID",1234);
            var r = command.ExecuteQuery();
        }
    }
