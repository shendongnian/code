    public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
    {
        IMethodReturn ret = getNext()(input, getNext);
        if (ret.Exception != null)
        {
            // Throw the Exception out of the Unity Interception
            ExceptionDispatchInfo.Capture(ret.Exception).Throw();
        }
        // Process return result
        return ret;
    }
    
    
