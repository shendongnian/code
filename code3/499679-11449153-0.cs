    public ObjectSet<Movie> Connection()
    {
        var connStr = ConfigurationManager.ConnectionStrings["Entities"];
        ObjectContext context = new ObjectContext(connStr.ConnectionString);
        var movieContext = context.CreateObjectSet<Movie>();
        return movieContext;
    }
