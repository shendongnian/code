    public void CreateDatabase(string connectionString)
    {
        var builder = new NpgsqlConnectionStringBuilder(connectionString);
        var databaseName = builder.Database; // REMEMBER ORIGINAL DB NAME
        builder.Database = "postgres"; // TEMPORARILY USE POSTGRES DATABASE
    
        // Create connection to database server
        using (var connection = new NpgsqlConnection(builder.ConnectionString))
        {
            connection.Open();
    
            // Create database
            var createCommand = connection.CreateCommand();
            createCommand.CommandText = string.Format(@"CREATE DATABASE ""{0}"" ENCODING = 'UTF8'", databaseName);
            createCommand.ExecuteNonQuery();
    
            connection.Close();
        }
    }
