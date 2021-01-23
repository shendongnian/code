    public IMethodReturn Invoke(IMethodInvocation input, 
        GetNextHandlerDelegate getNext)
    {
        var methodReturn = getNext().Invoke(input, getNext);
        if (methodReturn.Exception != null)
        {
            // exception was encountered... 
            var interceptedException = methodReturn.Exception
          
            // ... do whatever you need to do, for instance:
            if (interceptedException is ArgumentNullException)
            {
                // ... and so on...
            }             
        }
    }
