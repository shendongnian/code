    public static T Read<T>(this IDataRecord dr, string field) where T : class
    {
        return dr[field] as T ?? default(T);
    }
    
    public static T? ReadNullable<T>(this IDataRecord dr, string field) where T : ValueType
    {
        return dr[field] as T? ?? default(T?);
    }
    
    public static T Read<T>(this IDataRecord dr, string field, 
                            T defaultValue) where T : class
    {
        return dr[field] as T ?? defaultValue;
    }
    
    public static T? ReadNullable<T>(this IDataRecord dr, string field, 
                                     T? defaultValue) where T : ValueType
    {
        return dr[field] as T? ?? defaultValue;
    }
