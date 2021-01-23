    public T Get<T>()
    {
        var elementType = TypeSystem.GetElementType(typeof(T));
        ...
    }
