    var t = objectToCache.GetType();
    Attribute attr;
    var success = CacheAttributes.TryGetValue(t, out attr);
    if (!success)
    {
        attr = Attribute.GetCustomAttribute(t, typeof (CacheAttribute));
        CacheAttributes[t] = attr;
    }
    if (attr == null) return;
    var a = attr as CacheAttribute;
    TimeSpan span;
    //Continues with your code
