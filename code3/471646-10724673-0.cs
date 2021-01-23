    IDataAdapter GetAdapter(IDbConnection connection) {
    	var assembly = connection.GetType().Assembly;
    	var @namespace = connection.GetType().Namespace;	
    	
    	// Assumes the factory is in the same namespace
    	var factoryType = assembly.GetTypes()
    						.Where (x => x.Namespace == @namespace)
    						.Where (x => x.IsSubclassOf(typeof(DbProviderFactory)))
    						.Single();
    	
    	// SqlClientFactory and OleDbFactory both have an Instance field.
    	var instanceFieldInfo = factoryType.GetField("Instance", BindingFlags.Static | BindingFlags.Public);
    	var factory = (DbProviderFactory) instanceFieldInfo.GetValue(null);
    	
    	return factory.CreateDataAdapter();
    }
