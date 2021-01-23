    public virtual void Intercept(IInvocation invocation)
    {
        try
        {
            invocation.Proceed();
            var task = invocation.ReturnValue as Task;
            if (task != null)
            {
                invocation.ReturnValue = task.ContinueWith(t => {
                    if (t.IsFaulted)
                        OnException(invocation, t.Exception);
                });
            }
        }
        catch (Exception ex)
        {
            OnException(invocation, ex);
        }
    }
    public virtual void OnException(IInvocation invocation, Exception exception)
    {
        ...
    }
