    public static int? GetInt(this IDataReader r, string columnName)
    {
        var i = r[columnName];      
        if (i.IsNull())
            return null; //or your preferred value
        return (int)i;
    }
    public static bool IsNull<T>(this T obj) where T : class
    {
        return (object)obj == null || obj == DBNull.Value;
    }
