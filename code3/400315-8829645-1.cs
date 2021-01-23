    public T Upcast<T>() where T : Alpha
    {
        return this as T;  // will return null is this is not a T
    }
    ...
    new Beta().Upcast<Gamma>();  // will return null
    new Epsilon().Upcate<Epsilon>();  // will return the Epsilon
