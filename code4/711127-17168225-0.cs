    using (SqlConnection connection = new SqlConnection(
               connectionString))
    {
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandTimeout = 15;
        command.CommandType = CommandType.Text;
        command.CommandText = queryString;
        connection.Open();
       //Perfom desired Action
    }
