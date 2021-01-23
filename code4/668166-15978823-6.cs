    public static T Read<T>(T input)
    {
        Read(input, ExtensionMethods.ConversionA<T>);
    }
    public static T Read<T>(T input, Func<T, string> conversion)
    {
        // Logic goes here
    }
