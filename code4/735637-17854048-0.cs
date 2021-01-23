    public static bool IsExplicitInterfaceImplementation(PropertyInfo property)
    {
        if (!property.Name.Contains("."))
            return false;
        if (!property.GetMethod.IsFinal)
            return false;
        if (!property.GetMethod.IsVirtual)
            return false;
        if (!property.GetMethod.IsPrivate)
            return false;
    }
