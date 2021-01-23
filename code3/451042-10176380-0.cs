    Type t = typeof(StavkaDokumenta).GetProperty(pd.Polje).PropertyType;
    ParameterExpression pe = Expression.Parameter(typeof(StavkaDokumenta), "stavka");
    Expression expr = Expressions.ResolveCompleteExpression(pe, pd.Expression);
    Expression final = Expression.Convert(expr, t);
    
    if (t == typeof(string))
    {
        var lambda = Expression.Lambda<Func<string>>(final, null);
        o = lambda.Compile().Invoke();
    }
    else
    {
        var lambda = Expression.Lambda(final, pe);
        o = lambda.Compile().DynamicInvoke(stavka);
    }
