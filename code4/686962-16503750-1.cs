    static string GetPriorityName(Type enumType, object v)
    {
        Type ut = Enum.GetUnderlyingType(enumType);
        var pty = enumType.GetFields()
            .Where(
                a => a.IsLiteral 
                && a.GetRawConstantValue().Equals(v)
                && a.GetCustomAttributes(typeof(PriorityAttribute), false).Length > 0
                )
            .FirstOrDefault();
        if (pty == null) 
            return Enum.GetName(enumType, v); // default to standard if no priority defined
        return pty.Name;
    }
