    var msg = Message.CreateMessage(MessageVersion.Soap11, "*");
    msg.Headers.Clear();
    var proxyGenerator = new Castle.DynamicProxy.ProxyGenerator();
    var proxiedMessage = proxyGenerator.CreateClassProxyWithTarget(msg, new ProxyGenerationOptions(),
        new ToStringInterceptor());
