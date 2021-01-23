    Expression.Call(typeof(Console).GetMethod(
      "WriteLine", 
      BindingFlags.Public | BindingFlags.Static,
      null,
      new[] { typeof(string) },
      null), Expression.Constant(name));
