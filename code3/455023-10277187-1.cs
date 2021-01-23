    Type genericArgument = expr.GetGenericArguments()[0];
    mi = typeof(Queryable)
      .GetMethod("Count", 
        BindingFlags.Static | BindingFlags.Public, 
        null, 
        new [] { genericArgument }, null); 
