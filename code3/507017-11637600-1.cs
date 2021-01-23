    public static string AsString(this Enum value)
    {
        var type = value.GetType();
        if (!type.IsEnum)
            throw new ArgumentException();
        var fieldInfo = type.GetField(value.ToString());
        if (fieldInfo == null) 
            return value.ToString();
        var attribs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
        return attribs.Length > 0 ? attribs[0].Description : value.ToString();
    }
