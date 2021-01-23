    public static T Get<T>(this IDataReader r, string columnName)
    {
        var obj = r[columnName];      
        if (obj.IsNull())
            return default(T);
        return (T)obj;
    }
    
