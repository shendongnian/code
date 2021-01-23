    string connectionString = "...";
    using (OracleConnection connection = new OracleConnection(connectionString))
    {
        connection.Open();
        using(OracleCommand command = new OracleCommand(your query))
        {
           command.Connection = connection;
           command.ExecuteNonQuery();
        }
    }
