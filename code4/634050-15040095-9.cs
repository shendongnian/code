    public static Dictionary<int, string> GetEnumDictionary<T>()
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T is not an Enum type");
        if (Enum.GetUnderlyingType(typeof(T)) != typeof(int))
            throw new ArgumentException("The underlying type of the enum T is not Int32");
        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .ToDictionary(t => (int)(object)t, t => t.ToString());
    }
