    public static Func<bool, dynamic> Creator; 
 
    static void BuildLambda() { 
        var expectedType = typeof(MyObject); 
        var displayValueParam = Expression.Parameter(typeof(bool), "displayValue"); 
        var ctor = Expression.New(expectedType); 
        var local = Expression.Parameter(expectedType, "obj"); 
        var displayValueProperty = Expression.Property(local, "DisplayValue"); 
 
        var returnTarget = Expression.Label(expectedType); 
        var returnExpression = Expression.Return(returnTarget,local, expectedType); 
        var returnLabel = Expression.Label(returnTarget, Expression.Default(expectedType)); 
 
        var block = Expression.Block( 
            new[] { local }, 
            Expression.Assign(local, ctor), 
            Expression.Assign(displayValueProperty, displayValueParam), 
            /* I forgot to remove this line:
             * Expression.Return(Expression.Label(expectedType), local, expectedType), 
             * and now it works.
             * */
            returnExpression, 
            returnLabel 
            ); 
        Creator = 
            Expression.Lambda<Func<bool, dynamic>>(block, displayValueParam) 
                .Compile(); 
    }
