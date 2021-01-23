    Type type = typeof(DbContext).Assembly.GetType("System.Data.Entity.Internal.LazyInternalContext");
    object concurrentDictionary = (type.GetField("InitializedDatabases", BindingFlags.NonPublic | BindingFlags.Static)).GetValue(null);
    var initializedDatabaseCache = (IDictionary)concurrentDictionary;
    if (initializedDatabaseCache != null) initializedDatabaseCache.Clear();
    object concurrentDictionary2 = (type.GetField("CachedModels", BindingFlags.NonPublic | BindingFlags.Static)).GetValue(null);
    var modelsCache = (IDictionary)concurrentDictionary2;
    if (modelsCache != null) modelsCache.Clear();
