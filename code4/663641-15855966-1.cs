    if (Type.GetType(type) != null)
    {
        var enumType = Type.GetType(type);
        if (enumType.BaseType == typeof(Enum))
        {
            return Enum.Parse(enumType, value.ToString());
        }
    }
