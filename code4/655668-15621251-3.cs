    public static IEnumerable<FieldInfo> GetAllFieldsWithAttribute(this Type objectType, Type attributeType)
    {
        return objectType.GetFields().Where(
            f => f.GetCustomAttributes(attributeType, false).Any());
    }
