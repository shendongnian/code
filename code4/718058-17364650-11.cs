    public static T GetValue<T>(this XElement element, string name)
    {
        string value = (string)element.Element(name);    
        Type targetType =  typeof(T);
        if (targetType == typeof(Guid))
            return (T)(object)Guid.Parse(value);
        var typeConverter = TypeDescriptor.GetConverter(targetType);
        if (typeConverter == null || !typeConverter.CanConvertFrom(typeof(string)))
            return default(T); // or throw exception
        return (T)typeConverter.ConvertFrom(value);
    }
