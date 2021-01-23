    public static T Method<T>(T model) where T : class, new()
    {
        var m = model ?? new T();
    
        return m;
    }
