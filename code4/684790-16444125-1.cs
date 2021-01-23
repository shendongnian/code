    public static void Add<T>(T item) where T : Person, new()
    {
        var newItem = new T();
        ...
    }
