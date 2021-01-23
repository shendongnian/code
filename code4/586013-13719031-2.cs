    Type type = typeof(MyDictionary);
    foreach (Type iType in type.GetInterfaces()
                               .Where(i => i.IsGenericType))
    {
        Console.WriteLine(iType.Name);
        foreach (Type argType in iType.GetGenericArguments())
            Console.WriteLine("\t" + argType.Name);
    }
