    public static Array ListValuesFromEnum<T>()
    {
        Type enumType = typeof(T);
        Type underlyingType = Enum.GetUnderlyingType(enumType);
        Array enumValues = Enum.GetValues(enumType);
        var arr = Array.CreateInstance(underlyingType, enumValues.Length);
        for (int i = 0; i < arr.Length; i++)
        {
            arr.SetValue(Convert.ChangeType(
                 enumValues.GetValue(i), underlyingType), i);
        }
        return arr;
    }
