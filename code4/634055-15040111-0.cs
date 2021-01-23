    public static IDictionary<int, string> GetEnumDictionary<T>()
    where T : IConvertible
    {
        return Enum
           .GetValues(typeof(T))
           .Cast<T>()
           .ToDictionary(
               t => t.ToInt32(CultureInfo.InvariantCulture)
           ,   t => t.ToString()
           );
    }
