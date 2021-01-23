    private object InvokeInternal(System.Delegate @delegate)
    {
        try
        {
            return @delegate.DynamicInvoke();
        }
        catch (Exception ex)
        {
            throw LogAndThrowFaultException(ex);
        }
    }
