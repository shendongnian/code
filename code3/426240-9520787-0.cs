    // x and y are your object variables of the collections, 
    // argumentType is the generic type you determined
      var methods = from m in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                  where m.ContainsGenericParameters
                  && m.Name == "Except"
                  && m.GetParameters().Count() == 2
                  && m.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                  && m.ReturnType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                  select m;
      var method = methods.First();
      IEnumerable things = method.MakeGenericMethod(new Type[] { argumentType }).Invoke(null, new [] { x, y }) as IEnumerable;
