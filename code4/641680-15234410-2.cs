    public static string ToStringEx(this Enum enumeration)
    {
        Type type = enumeration.GetType();
        FieldInfo field = type.GetField(enumeration.ToString());
        var enumString =
            (from attribute in field.GetCustomAttributes(true)
             where attribute is EnumStringAttribute
             select attribute).FirstOrDefault();
        if (enumString != null)
            return enumString.ToString();
        // otherwise...
        return enumeration.ToString();
    }
