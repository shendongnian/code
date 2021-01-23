    // For reference types
    public static T Method<T>(T model) where T : class, new()
    {
        return model ?? new T();
    }
    
    // For Nullable<T>
    public static T Method<T>(T? model) where T : struct
    {
        return model ?? new T();
    }
