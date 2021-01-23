    static string _connection;
    public MyContext()
        : base(_connection ?? "DefaultConection")
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, MyNamespace.Migrations.Configuration>());
    }
    public MyContext(string connection)
        : base(connection)
    {
        _connection = connection;
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, MyNamespace.Migrations.Configuration>());
    }
