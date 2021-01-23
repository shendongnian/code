    public static void MyFunction<T>(T en) where T: IComparable, IFormattable, IConvertible
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("en must be enum type");
        // implementation
    }
