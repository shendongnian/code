    public IMethodReturn Invoke(IMethodInvocation input,
                                GetNextInterceptionBehaviorDelegate getNext)
    {
        try
        {
            return InvokeImpl(input, getNext);
        }
        catch (Exception exception)
        {
            // Process exception and return result
        }
    }
    private IMethodReturn InvokeImpl(IMethodInvocation input,
                                    GetNextInterceptionBehaviorDelegate getNext)
    {
        var methodReturn = getNext().Invoke(input, getNext);
        if (methodReturn.Exception != null)
            // Process exception and return result
        return methodReturn;
    }
