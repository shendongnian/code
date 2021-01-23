    public static IEnumerable<MemberInfo> GetStateMembers(this Type t)
    {
        return t.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.MemberType == MemberTypes.Field && !((FieldInfo)m).Name.Contains('<')
                         || m.MemberType == MemberTypes.Property && ((PropertyInfo)m).IsAutoProperty());
    }
    public static bool IsAutoProperty(this PropertyInfo prop)
    {
        if (!prop.CanWrite || !prop.CanRead)
            return false;
        return prop.DeclaringType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                 .Any(f => f.Name.Contains("<" + prop.Name + ">"));
    }
