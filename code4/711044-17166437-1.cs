    public static ReadOnlyCollection<EnumerationMember> ListValuesFromEnum<T>()
    {
        Type enumType = typeof(T);
        Type underlyingType = Enum.GetUnderlyingType(enumType);
        T[] enumValues = (T[])Enum.GetValues(enumType);
        return enumValues
            .Select(ev => new EnumerationMember(Convert.ChangeType(ev,underlyingType), ev.ToString()))
            .ToList()
            .AsReadOnly();
    }        
