    private void InsertData()
    {
        using (var connection = new SqlConnection("YOUR_CONNECTION_STRING_HERE"))
        using (var command = connection.CreateCommand())
        {
            // populate command details
     
            connection.Open();
    
            var affectedRows = command.ExecuteNonQuery();
    
            // do whatever
        }
    }
