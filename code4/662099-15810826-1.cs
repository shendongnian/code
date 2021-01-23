    using(var connection = new SqlConnection("your connectionstring goes here"))
    {
        using(var command = new SqlCommand(sqlQuery,                                                                          connection))
        {
            command.Parameters.AddWithValue("@id ", yourIDvalue);
            command.Parameters.AddWithValue("@firstname ", FirstName);    
            command.Parameters.AddWithValue("@surname", surname);    
            var reader = command.ExecuteReader();
        }
    }
