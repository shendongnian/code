    public IList<T> MyMethod<T>() where T : class, IMyInterface1
    {
        if (typeof(IMyInterface2).IsAssignableFrom(typeof(T))
        {
            // do stuff with items...
        }
        return myResult;
    }
