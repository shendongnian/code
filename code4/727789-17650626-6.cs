    // using SimpleInjector.Advanced; // for IsVerifying()
    container.Register<HttpRequestMessage>(() =>
    {
        var context = HttpContext.Current;
        if (context == null && container.IsVerifying())
            return new HttpRequestMessage();
        
        object message = context.Items["__message"];
        return (HttpRequestMessage)message;
    });
