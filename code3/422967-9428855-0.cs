    static void Main(string[] args)
    {
        Object result =
            ConvertValue(
                "System.Nullable`1[[System.DateTime, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]",
                "2012-02-23 10:00:00");
    }
    
    public static Object ConvertValue(string typeInString, string value)
    {
        Type originalType = Type.GetType(typeInString);
        
        var underlyingType = Nullable.GetUnderlyingType(originalType);
    
        // if underlyingType has null value, it means the original type wasn't nullable
        object instance = Convert.ChangeType(value, underlyingType ?? originalType);
    
        return instance;
    }
