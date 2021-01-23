    using (SqlConnection connection = new SqlConnection())
    {
        connection.ConnectionString = "valid connection string here";
        // then pass the connection to your command object
        using (SqlCommand command = new SqlCommand())
        {
             command.Connection = connection;
             // other codes
        }
    }
