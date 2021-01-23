    Type genericArgument = expr.GetGenericArguments()[0];
    mi = typeof(Queryable)
      .GetMethod("Count", BindingFlags.Static | BindingFlags.Public, 
      null, 
      new[] { typeof(IQueryable<>) }, null)
      .MakeGenericMethod(genericArgument);
    //now you can bind to mi
