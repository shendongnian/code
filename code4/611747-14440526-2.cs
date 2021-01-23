    public static List<Type> GetTypesWithMyAttribute(Assembly assembly)
    {
        List<Type> types = new List<Type>();
        foreach(Type type in assembly.GetTypes())
        {
            if (type.GetCustomAttributes(typeof(MyAttribute), true).Length > 0)
                types.Add(type);
        }
        return types;
    }
