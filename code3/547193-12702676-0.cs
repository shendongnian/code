    ServerConnection connection = new ServerConnection(sqlServerName, sqlUserName, sqlPassword);
    Server server = new Server(connection);
    Database database = server.Databases[databaseName];
    foreach (var sqlFile in Directory.EnumerateFiles(folder, "*.sql"))
    {
        //Parses the file and runs the batches
        database.ExecuteNonQuery(File.ReadAllText(sqlFile));
    }
