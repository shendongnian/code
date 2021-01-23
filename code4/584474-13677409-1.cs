    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand command1 = new SqlCommand(commandText1, connection))
        {
        }
        using (SqlCommand command2 = new SqlCommand(commandText2, connection))
        {
        }
        // etc
    }
