    public static T Read<T>(string fileName, Func<T, string> func) // non-optional parameter
    {
        /* ... */
    }
    
    public static T Read<T>(string fileName)
    {
        return Read<T>(fileName, ExtensionMethods.ConversionA<T>);
    }
