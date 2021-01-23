    MyClass<int> c = new MyClass<int>();
    Type concreteType = c.GetType();
    Console.Write("Concrete type name:");
    Console.WriteLine(concreteType.FullName);
    Console.WriteLine();
    MethodInfo concreteMethod = concreteType.GetMethod("Foo");
    if (concreteMethod != null)
    {
        Console.WriteLine(concreteMethod.Name);
        foreach (ParameterInfo pinfo in concreteMethod.GetParameters())
        {
            Console.WriteLine(pinfo.Name);
            Console.WriteLine(pinfo.ParameterType);
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    if (concreteType.IsGenericType)
    {
        Console.Write("Generic type name:");
        Type genericType = concreteType.GetGenericTypeDefinition();
        Console.WriteLine(genericType.FullName);
        Console.WriteLine();
        MethodInfo genericMethod = genericType.GetMethod("Foo");
        if (genericMethod != null)
        {
            Console.WriteLine(genericMethod.Name);
            foreach (ParameterInfo pinfo in genericMethod.GetParameters())
            {
                Console.WriteLine(pinfo.Name);
                Console.WriteLine(pinfo.ParameterType);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
