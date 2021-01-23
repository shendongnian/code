    internal static object CreateInstanceWithParam(Type type, object template)
    {
        TypeAccessor target = TypeAccessor.Create(type),
            source = TypeAccessor.Create(template.GetType());
        if (!target.CreateNewSupported)
                throw new InvalidOperationException("Cannot create new instance");
        if (!source.GetMembersSupported)
                throw new InvalidOperationException("Cannot enumerate members");
        object obj = target.CreateNew();
        foreach (var member in source.GetMembers())
        {
            target[obj, member.Name] = source[template, member.Name];
        }
        return obj;
    }
