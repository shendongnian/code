    public T Factory<T>(params object[] args): where T is MyBaseClass
    {
        var argList = new List<object>(args);
        var type = typeof(T);
        var argtypes = argList.Select(o => o.GetType()).ToArray();
        var constructor = type.GetConstructor(argtypes);
        return constructor.Invoke(args) as T;
    }
