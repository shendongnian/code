    // at the top of your class
    private static readonly object AnonymousObjectWithLotsOfProperties = new {
        a = 1,
        b = 2,
        ...
    };
    // then in your method
    // (1) first get the list of properties represented by the string you passed in (I assume you know how to do this via reflection)
    var props = typeof(T).GetProperties().Where(...);
    var propTypes = props.Select(pi => pi.PropertyType).ToList();
    
    // (2) now generate the correctly genericized anonymous type to use
    var genericTupleType = AnonymousObjectWithLotsOfProperties.GetType()
        .GetGenericTypeDefinition();
    // for generic args, use the prop types and pad with int
    var genericArguments = propTypes.Concat(Enumerable.Repeat(typeof(int), genericTupleType.GetProperties().Length - propTypes.Count))
        .ToArray();
    var tupleType = genericTupleType.MakeGenericType(genericArguments);
    
    // (3) now we have to generate the x => new { ... }  expression
    // if you inspect "System.Linq.Expressions.Expression<Func<object>> exp = () => new { a = 2, b = 3 };"
    // in the VS debugger, you can see that this is actually a call to a constructor
    // on the anonymous type with 1 argument per property
    var tParameter = Expression.Parameter(typeof(T));
    // create the expression
    var newExpression = Expression.New(
        constructor: tupleType.GetConstructors().Single(), // get the one constructor we need
        // the arguments are member accesses on the parameter of type T, padded with 0
        arguments: props.Select(pi => Expression.MakeMemberAccess(tParameter, pi))
            .Concat(Enumerable.Repeat(Expression.Constant(0), genericTupleType.GetProperties().Length - propTypes.Count))
    );
    // create the lambda: we need an Expression<TDelegate>, which means that we
    // need to get the generic factory method from Expression and invoke it
    var lambdaGenericMethod = typeof(Expression).GetMethods(BindingFlags.Static | BindingFlags.Public)
        .Single(m => m.IsGenericMethodDefinition);
    var lambdaMethod = lambdaGenericMethod.MakeGenericMethod(typeof(Func<,>).MakeGenericType(typeof(T), tupleType));
    // reflection for Expression.Lambda(body, parameters)
    var lambda = lambdaGenericMethod.Invoke(null, new object[] { newExpression, new[] { tParameter });
    
    // now that we have the expression, we can invoke GroupBy via reflection.
    // Of course, that leaves you with an IQueryable<IGrouping<ANON, T>>, which isn't much
    // use until you apply some other IQueryable methods to eliminate the ANON type from the
    // method signature so you can return it
