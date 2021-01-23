    function LINQSelectNew(Expression expr, string[] args)
    {
    Type type = expr.Type.GetGenericArguments()[0];
    ParameterExpression parameter = Expression.Parameter(type, type.Name);
    List<Expression> lista = new List<Expression>();                    
    foreach (string s in args) lista.Add(Expressions.ResolveCompleteExpression(parameter, s.Prepare()));
    
    Expression New = Expression.New(typeof(LookupModel).GetConstructor(lista.Select(e => e.Type).ToArray()), lista.ToArray());
    return Expression.Call(
        typeof(Queryable),
        "Select",
        new Type[] { type, New.Type },
        expr,
        Expression.Lambda(New, new ParameterExpression[] { parameter }));
    }
