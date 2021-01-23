    Type type = typeof(MyGenericClass);
    foreach (Type iType in type.GetInterfaces().Where(i => i.IsGenericType))
    {
        Console.WriteLine(iType.FullName);
        Console.WriteLine("");
        foreach (Type argType in iType.GetGenericArguments())
            Console.WriteLine(argType.FullName);
        Console.WriteLine();
    }
