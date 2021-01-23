    public object GetInstance(Type type)
    {
        return Activator.CreateInstance(type);
    }
    int i = GetInstance(typeof(int)) as int;
    public T GetInstance<T>()
    {
        return Activator.CreateInstance<T>();
    }
    int i = GetInstance<int>();
    public T GetInstance<T>(T template)
    {
        return Activator.CreateInstance<T>();
    }
    int i = GetInstance(0);
