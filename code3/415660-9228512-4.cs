    private IDictionary<Type, object> _objectPool;
    public T RetrieveFromPool<T>() where T : new() 
    {
      Type type = typeof(T);
      return _objectPool.ContainsKey(type) ? (T)_objectPool[type] : new T();
    }
    // Update - add a couple of templates for add methods:
    
    public void AddToPool<T>() where T : new
    {
      _objectPool[typeof(T)] = new T();
    }
    public void AddToPool<T>(T poolObject) where T : new
    {
      _objectPool[typeof(T)] = poolObject;
    }
