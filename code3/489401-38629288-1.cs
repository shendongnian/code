        var interfaces = someType.GetType().GetInterfaces(); 
        //DotNet4.5: var interfaces = someType.GetType()
        //               .GetTypeInfo().ImplementedInterfaces;
        bool condition = (interfaces != null && interfaces.ToList()
                         .Contains(typeof(ISomeInterface<SomeClass>)) == true);
