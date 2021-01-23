    public static DbDataAdapter CreateDataAdapter(DbConnection connection)
    {
       var factory = DbProviderFactories.GetFactory(connection);
       DbProviderFactory factory = null;
          if (factory == null)
             throw new ArgumentException("Could not locate factory matching supplied DbConnection", "connection");
       return factory.CreateDataAdapter();
    }
