    using(var connection = new SqlConnection("your connectionstring goes here"))
    {
        using(var command = new SqlCommand("select* from Table where code=@dateTime", 
                                                                                 connection))
        {
            command.Parameters.AddWithValue("@dateTime", DateTime.Now);
    
            var reader = command.ExecuteReader();
        }
    }
