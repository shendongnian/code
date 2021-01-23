    public static Action<object> CreateReusableAction<TClass>(string methodName)
    {
        var method = typeof(TClass).GetMethod(methodName);
        var del = Delegate.CreateDelegate(typeof(Action<TClass>), method);
        Action<object> caller = (instance) => del.DynamicInvoke(instance);
        return caller;
    }
    
    public static Action<object, TParam1> CreateReusableAction<TClass, TParam1>(string methodName)
    {
        var method = typeof(TClass).GetMethod(methodName, new Type[] { typeof(TParam1) });
        var del = Delegate.CreateDelegate(typeof(Action<TClass, TParam1>), method);
        Action<object, TParam1> caller = (instance, param) => del.DynamicInvoke(instance, param);
        return caller;
    }
    
    public static Func<object, TParam1, TReturn> CreateReusableFunction<TClass, TParam1, TReturn>(string methodName)
    {
        var method = typeof(TClass).GetMethod(methodName, new Type[] { typeof(TParam1) });
        var del = Delegate.CreateDelegate(typeof(Func<TClass, TParam1, TReturn>), method);
        Func<object, TParam1, TReturn> caller = (instance, param) => (TReturn)del.DynamicInvoke(instance, param);
        return caller;
    }
