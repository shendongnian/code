    public static IEnumerable<Type> GetTypesWithMyAttribute(Assembly assembly)
    {
        foreach(Type type in assembly.GetTypes())
        {
            if (type.GetCustomAttributes(typeof(MyAttribute), true).Length > 0)
                yield return type;
        }
    }
