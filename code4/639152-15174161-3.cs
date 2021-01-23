    private static Type[] defaultTypes = new Type[]
    {
        typeof(System.SByte),
        typeof(System.Byte), 
        typeof(System.Int16), 
        typeof(System.UInt16), 
        typeof(System.Int32), 
        typeof(System.UInt32), 
        typeof(System.Int64), 
        typeof(System.UInt64), 
        typeof(System.Single), 
        typeof(System.Double), 
        typeof(System.Decimal),
        typeof(System.DateTime),
        typeof(System.Guid)
    };
    public static dynamic ConvertToType(string value)
    {
        return ConvertToType(value, defaultTypes);
    }
    public static dynamic ConvertToType(string value, Type[] types)
    {
        foreach (Type type in types)
        {
            if (!value.CanConvertTo(type))
                continue;
            return Convert.ChangeType(value, type);
        }
        return value;
    }
