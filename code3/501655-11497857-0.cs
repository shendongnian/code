    public T FillA<T>() where T : A, new()
    {
        T newobj = new T();
        newobj.AProperty1 = valueForProperty1;
        newobj.AProperty2 = valueForProperty2;
        // etc.
        return newobj;
    }
