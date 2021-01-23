    public static TResult CallMethod<TResult>(Func<TResult> func)
    {
        try
        {
            return func();
        }
        catch(ThirdPartyException e)
        {
            // Handle
        }
    }
    public static void CallMethod(Action method)
    {
        CallMethod(() => { method(); return 0; });
    }
