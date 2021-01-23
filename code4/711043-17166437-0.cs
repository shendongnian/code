    public static ReadOnlyCollection<object> ListValuesFromEnum<T>()
    {
        Type enumType = typeof(T);
        Type underlyingType = Enum.GetUnderlyingType(enumType);
        T[] enumValues = (T[])Enum.GetValues(enumType);
        return enumValues
             .Select(ev => Convert.ChangeType(ev,underlyingType))
             .ToList()
             .AsReadOnly();
    }
