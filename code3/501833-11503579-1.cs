    public IList<T> MyMethod<T>() where T : class, IMyInterface1
    {
        if (typeof(IMyInterface2).IsAssignableFrom(typeof(T)))
        {
            // code here
        }
        return myResult;
    }
