    ConcurrentDictionary<int,object> lockObjects = new ConcurrentDictionary<int,object)
    public void UpdateMySpecialEntity(Entity foo)
    {
        object idLock =  lockObject.GetOrAdd(foo.id,new object());
        lock (idLock)
        {
        // do lock sensitive stuff in here.
        }
    }
