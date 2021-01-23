    public static Boolean CanCovertTo(this String value, Type type)
    {
        var targetType = type.IsNullableType() ? Nullable.GetUnderlyingType(type) : type;
        TypeConverter converter = TypeDescriptor.GetConverter(targetType);
        return converter.IsValid(value);
    }
