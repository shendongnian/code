    public static Dictionary<int, string> EnumToDictionary<T>() 
                  where T : struct, IComparable, IFormattable, IConvertible
    {
        var type = typeof(T);
        if (!type.IsEnum) throw new TypeArgumentException("Only enums are allowed!");
        return Enum.GetValues(type).Cast<int>()
                   .ToDictionary(key => key, value => Enum.GetName(type, value));
    }
