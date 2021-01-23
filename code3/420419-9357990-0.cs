    DbProviderFactory factory =   DbProviderFactories.GetFactory("System.Data.OleDb");
    
    using (DbConnection connection = factory.CreateConnection())
    {
        connection.ConnectionString = connectionString;
    
        using (DbCommand command = connection.CreateCommand())
        {
            command.CommandText = "INSERT INTO [Cities$] (ID, City, State) VALUES(4,\"Tampa\",\"Florida\")";
    
            connection.Open();
    
            command.ExecuteNonQuery();
        }
    }
