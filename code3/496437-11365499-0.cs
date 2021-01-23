    Try with Oracle provider, add reference to System.Data.OracleClient assembly
    
    use OracleConnection as in this example
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
