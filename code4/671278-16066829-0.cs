    var pe = Expression.Parameter( typeof( T )); // <<== Here
    var memberExpression = Expression.PropertyOrField(pe /* Here */, "MyProperty");
    var equalExpression = Expression.Equal( memberExpression, Expression.Constant( const ) );
    var compiled = Expression.Lambda<Func<T, bool>>( equalExpression, pe ).Compile();
    //                                                                ^^
    //                                                                ||
    //                                                             And here
