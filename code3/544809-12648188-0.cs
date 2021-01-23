    protected override void Init() { Kernel.ComponentRegistered += KernelComponentRegistered; }
    static void KernelComponentRegistered(string key, IHandler handler)
    {
        if (typeof(IInterceptor).IsAssignableFrom(handler.ComponentModel.Implementation)) return; //This is so that interceptors don't intercept themselves
        
        if (handler.ComponentModel.Services.FirstOrDefault() == typeof(Test)) return; //This is so that the interceptor does not intercept our Factory-initialized class
        
        handler.ComponentModel.Interceptors.AddIfNotInCollection(InterceptorReference.ForKey("SomeInterceptor"));
    }
}
