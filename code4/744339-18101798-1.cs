    foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
        .Where(type => type.GetCustomAttributes(true)
                           .Any(attr => attr.GetType() == (typeof(MyAttribute)))))
    {
         builder.RegisterType(type).Keyed("CachableQueries",
             type.GetInterfaces()
                 .First(i => 
                        i.IsGenericType && 
                        i.GetGenericTypeDefinition() == typeof(IMyInterface<,>)));
    }
