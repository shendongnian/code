    var interfaceType = type.GetInterfaces().Single();
    var proxy = generator.CreateClassProxy(type,
        new Type[] { interfaceType },
        new IInterceptor[]
        {
            new CacheInterceptor(), 
            new LoggingInterceptor()
        });
    // I'm using directive ToConstant(..), and not To(..)
    Bind(interfaceType).ToConstant(proxy).InThreadScope();
