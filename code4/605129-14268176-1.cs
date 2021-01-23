    public static IEnumerable<string> EnumToStringArray(Type enumeratedType) {
        if (!enumeratedType.IsEnum)
            throw new ArgumentException("Must be an Enum", "enumeratedType");
        return Enum.GetNames(enumeratedType);
    }
