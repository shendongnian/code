    public static Dictionary<int, string> GetEnumDictionary<T>()
    {
        return Enum.GetValues(typeof(T))
           .Cast<T>()
           .ToDictionary(t => (int)(object)t, t => t.ToString());
    }
