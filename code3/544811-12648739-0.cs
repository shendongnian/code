    try
    {
        ProxyGenerator generator = new ProxyGenerator();
        generator.CreateClassProxy(handler.ComponentModel.Implementation);
        handler.ComponentModel.Interceptors.AddIfNotInCollection(InterceptorReference.ForType<MyInterceptor>());
    }
    catch {}
