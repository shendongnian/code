    public TResult CallMethod<TResult>(Func<ThirdPartyClass, TResult> func)
    {
        try
        {
            return func(this.wrappedObject);
        }
        catch(ThirdPartyException e)
        {
            // Handle
        }
    }
    public void CallMethod(Action<ThirdPartyClass> method)
    {
        this.CallMethod(() => { method(this.WrappedObject); return 0; });
    }
