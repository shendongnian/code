    using(var connection = new SqlConnection(ConnectionString))
    {
        connection.Open();
        using(var command = new SqlCommand("SELECT * FROM Table WHERE ID=@someID",connection))
        {
            command.Parameters.AddWithValue("someID",1234);
            var r = command.ExecuteQuery();
        }
    }
