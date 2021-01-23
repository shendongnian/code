    public static unsafe bool IsBlittable(this Type T)
    {
        while (T.IsArray)
            T = T.GetElementType();
        bool b;
        if (!((b = T.IsPrimitive || T.IsEnum) || T.IsAbstract || T.IsAutoClass || T.IsGenericType))
            try
            {
                GCHandle.Alloc(FormatterServices.GetUninitializedObject(T), GCHandleType.Pinned).Free();
                b = true;
            }
            catch { }
        return b;
    }
