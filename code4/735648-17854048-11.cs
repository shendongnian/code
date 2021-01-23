    public static bool IsExplicitInterfaceImplementation(PropertyInfo property)
    {
        // This check is not mandatory and not cross-languages.
        // How this method is named may vary
        if (!property.Name.Contains("."))
            return false;
        if (property.Name.StartsWith("get_"))
            return false;
        if (!property.GetMethod.IsFinal)
            return false;
        if (!property.GetMethod.IsVirtual)
            return false;
        if (!property.GetMethod.IsPrivate)
            return false;
        return true;
    }
