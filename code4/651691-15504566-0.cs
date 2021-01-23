    using (var connection = new SqlConnection(...))
    using (var command = connection.CreateCommand())
    {
        // populate command details
     
        connection.Open();
    
        var affectedRows = command.ExecuteNonQuery();
    
        // do whatever
    }
