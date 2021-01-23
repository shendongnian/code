    public static DbDataAdapter CreateDataAdapter(DbConnection connection)
    {
       DbProviderFactory factory = null;
       factory = DbProviderFactories.GetFactory(connection);
       
       if (factory == null)
             throw new ArgumentException("Could not locate factory matching supplied DbConnection", "connection");
       return factory.CreateDataAdapter();
    }
