    IEnumerable<string> EnumerateConnections()
    {
        var lazyInternalContextType = typeof(DbContext).Assembly
            .GetType("System.Data.Entity.Internal.LazyInternalContext");
        var propertyDbs = lazyInternalContextType.GetField(
            "InitializedDatabases", 
            BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        var lazyContext = propertyDbs.GetValue(null);
        foreach (var pair in (IEnumerable)lazyContext)
        {
            var key = pair.GetProperty<object>("Key");
            var tuple = (Tuple<System.Data.Entity.Infrastructure.DbCompiledModel, string>)key;
            yield return tuple.Item2;
        }
    }
    var connectionName = EnumerateConnections().Distinct().SingleOrDefault();
