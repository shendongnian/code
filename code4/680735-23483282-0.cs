    public List<object> Foo(SqlConnection connection)
    {
        var query = "[dbo].[FooBar]";
        var command = new SqlCommand(query, connection);
        command.CommandType = CommandType.StoredProcedure;
        connection.Open();
        
        var reader = command.ExecuteReader();
        var results = new List<object>(); // Or whatever type your data is.
        while (reader.Read())
        {
            // Make this work for your particular data structure:
            results.Add(reader.GetString(0));
        }
        connection.Close();
    
        return results;
    }
