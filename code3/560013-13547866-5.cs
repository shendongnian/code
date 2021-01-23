    public static Action<object> CreateReusableAction<TClass>(string methodName)
    {
        var method = typeof(TClass).GetMethod(methodName);
        var del = Delegate.CreateDelegate(typeof(Action<TClass>), method);
        Action<object> caller = (instance) => del.DynamicInvoke(instance);
        return caller;
    }
    
    public static Action<object, object> CreateReusableAction<TClass, TParam1>(string methodName)
    {
        var method = typeof(TClass).GetMethod(methodName, new Type[] { typeof(TParam1) });
        var del = Delegate.CreateDelegate(typeof(Action<TClass, TParam1>), method);
        Action<object, object> caller = (instance, param) => del.DynamicInvoke(instance, param);
        return caller;
    }
    
    public static Func<object, object, object> CreateReusableFunction<TClass, TParam1, TReturn>(string methodName)
    {
        var method = typeof(TClass).GetMethod(methodName, new Type[] { typeof(TParam1) });
        var del = Delegate.CreateDelegate(typeof(Func<TClass, TParam1, TReturn>), method);
        Func<object, object, object> caller = (instance, param) => (TReturn)del.DynamicInvoke(instance, param);
        return caller;
    }
