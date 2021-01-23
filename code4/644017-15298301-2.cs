    var parameter = Expression.Parameter(typeof(int), "i");
    var newExpr = Expression.New(typeof(Foo));
    var bindExprs = new[]
        {
            Expression.Bind(typeof(Foo).GetProperty("Property"), parameter)
            // You can bind more properties here if you like.
        };
    
    var body = Expression.MemberInit(newExpr, bindExprs);
    var lambda = Expression.Lambda<Func<int, Foo>>(body, parameter);
