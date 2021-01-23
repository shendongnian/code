    Type genericArgument = expr.GetGenericArguments()[0];
    var matches = typeof(Queryable)
      .GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == "Count");
    var mi = typeof(matches.Single(m => m.GetParameters().Length == 1);
    //now you need to 'make' the generic method
    mi = mi.MakeGenericMethod(genericArgument);
