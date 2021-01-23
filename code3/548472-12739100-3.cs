    private Dictionary<Type, object> dataStore = new Dictionary<Type, object>();
    
    public void Insert<T>(T dto) where T : IDataTransferObject
    {
    	object data;
    	if (!dataStore.TryGetValue(typeof(T), out data))
    	{
    		var typedData = new List<T>();
    		dataStore.Add(typeof(T), typedData);
    		typedData.Add(dto);
    	}
    	else
    	{
    		((List<T>)data).Add(dto);
    	}
    }
    
    //you didn't provide a "getter" in your sample, so here's a basic one
    public List<T> Get<T>() where T : IDataTransferObject
    {
    	object data;
    	dataStore.TryGetValue(typeof(T), out data);
    	return (List<T>)data;
    }
