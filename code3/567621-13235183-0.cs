    public void Intercept(IInvocation invocation)
    {
        var logger = LoggerFactory.GetLogger(invocation.Request.Method.DeclaringType);
        var debug = !invocation.Request.Method.IsSpecialName && logger.IsDebugEnabled;
        if (debug)
            logger.Debug(invocation.Request.Method.Name);
        try
        {
            invocation.Proceed();
            if (debug)
                logger.Debug(invocation.Request.Method.Name + " FINISH");
        }
        catch (Exception)
        {
            logger.Error(invocation.Request.Method.Name + " ERROR");
            throw;
        }
    }
