        LabelTarget returnTarget = Expression.Label(typeof(bool));
        ParameterExpression para = Expression.Parameter(typeof(int), "intvalue");
        Expression test = Expression.GreaterThan(para, Expression.Constant(5));
        Expression iftrue = Expression.Return(returnTarget, Expression.Constant(true));
        Expression iffalse = Expression.Return(returnTarget, Expression.Constant(false));
        var ex = Expression.Block(
            Expression.IfThenElse(test, iftrue, iffalse),
            Expression.Label(returnTarget, Expression.Constant(false)));
        var compiled = Expression.Lambda<Func<int, bool>>(
            ex,
            new ParameterExpression[] { para }
        ).Compile();
        Console.WriteLine(compiled(5));     // prints "False"
        Console.WriteLine(compiled(6));     // prints "True"
