    var db = DependencyResolver.Current.GetService<Provider>();
    if (db == null)
    {
        throw new NullReferenceException("Service Provider not found.");
    }
    if (db is SybaseProvider)
    {
        map.Column(c => c.Default("now(*)"));
    }
    else // SQLite
    {
        map.Column(c => c.Default("CURRENT_TIMESTAMP"));
    }
    map.Generated(PropertyGeneration.Insert);
    map.NotNullable(true);
