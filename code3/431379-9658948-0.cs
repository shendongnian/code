    static Expression InArguments(
        ParameterExpression pe, string[] arguments, Type itemType)
    {
        List<Expression> listaExpr = new List<Expression>();
        foreach (string s in arguments)
        {
            Expression expression = Complete(pe, s, itemType); // evaluate argument
            listaExpr.Add(expression, typeof(object));
        }
        return Expression.NewArrayInit(itemType, listaExpr);
    }
