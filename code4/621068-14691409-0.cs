    public static Dictionary<int, string> getDictionaryFromEnum(Type enumType)
    {
        return Enum.GetValues(enumType).Cast<object>()
                   .ToDictionary(x => (int)x, x => x.ToString());
    }
