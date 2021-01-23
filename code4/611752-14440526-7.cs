    public static IEnumerable<Type> GetTypesWithMyAttribute(Assembly assembly)
    {
        foreach(Type type in assembly.GetTypes())
        {
            if (Attribute.IsDefined(type, typeof(MyAttribute)))
                yield return type;
        }
    }
