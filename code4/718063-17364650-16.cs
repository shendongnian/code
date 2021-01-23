    public static Nullable<T> GetValue<T>(this XElement element, string name)
        where T : struct
    {
        string value = (string)element.Element(name);
        if (value == null)
            return null;
        Type targetType =  typeof(T);
        if (targetType == typeof(Guid))
            return (T)(object)Guid.Parse(value);
        var typeConverter = TypeDescriptor.GetConverter(targetType);
        if (typeConverter == null || !typeConverter.CanConvertFrom(typeof(string)))
            return null; // or throw exception
        return (T)typeConverter.ConvertFrom(value);
    }
