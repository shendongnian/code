    public static TRet NullOr<T, TRet>(this T obj, Func<T, TRet> getter) where T : class
    {
        return obj != null ? getter(obj) : default(TRet);
    }
    
    public static void NullOrDo<T>(this T obj, Action<T> action) where T : class
    {
        if (obj != null)
            action(obj);
    }
