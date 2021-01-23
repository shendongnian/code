    public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
    {
        IMethodReturn r = getNext()(input, getNext);
        if (r.Exception != null) r.Exception = new Exception("NameOfInterceptor", r.Exception);
        return r;
    }
