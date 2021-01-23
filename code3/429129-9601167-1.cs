    private static TableCollection GetTables()
    {
        Server server = new Server(…);
        Database database = server.Databases[…];
        var tables = database.Tables;
        return tables;
    }
    …
    Parallel.For(0, GetTables().Count,
        i =>
        {
            var stringCollection = GetTables()[i].Script();
            …
        });
