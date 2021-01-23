    TimerInterceptor : IInterceptor
    {
	    public void Intercept(IInvocation invocation)
        {
            Stopwatch watch = new Stopwatch();
			watch.Start();
            invocation.Proceed();
	        watch.Stop();
            //here you have the value which could be used to log (which I assume you want)
        }
    }
    new ProxyGenerator().CreateInterfaceProxyWithTarget<IMyInterface>(implementedObject, new TimerInterceptor());
