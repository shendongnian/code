    public void Update<T>(string fieldName, string fieldValue)
    {
        System.Reflection.PropertyInfo propertyInfo = typeof(T).GetProperty(fieldName);
        Type propertyType = propertyInfo.PropertyType;
    
        TypeConverter converter = TypeDescriptor.GetConverter(type);
        if (converter.CanConvertFrom(typeof(string)))
        {
            var a = converter.ConvertFrom(fieldValue, type);
            ...
        }
    }
