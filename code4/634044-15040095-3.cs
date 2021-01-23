    public static Dictionary<int, string> GetEnumDictionary<T>()
    {
        if(!typeof(T).IsEnum)
           throw new ArgumentException("T is not an Enum type");
        return Enum.GetValues(typeof(T))
           .Cast<T>()
           .ToDictionary(t => (int)(object)t, t => t.ToString());
    }
