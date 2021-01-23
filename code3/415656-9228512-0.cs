    private IDictionary<string, object> _objectPool;
    object RetriveFromPool(string typeName)
    {     
        if(_objectPool.ContainsKey(typeName))
        {
            return _objectPool[typename]; // return from the pool
        }
        return Activator.CreateInstance(Type.GetType(typeName)); // Try to create a new object using the default constructor
     }
