    Type queryType = typeof(XPQuery<>);
    Type[] typeArgs = { typelist[0] };
    
    Type constructed = queryType .MakeGenericType(typeArgs);
    object myQuery = Activator.CreateInstance(constructed, XPODefault.Session);
