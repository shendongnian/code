    public LambdaExpression GetInnerLambda()
    {
        var param = Expression.Parameter(typeof(object));
        return Expression.Lambda(
            Expression.Block(
                Expression.Call(null,
                    typeof(ForSO).GetMethod("Write"),
                    Expression.Constant("Inner lambda start")),
                Expression.Call(null,
                    typeof(ForSO).GetMethod("Write"),
                    param),
                Expression.Call(null,
                    typeof(ForSO).GetMethod("Write"),
                    Expression.Constant("Inner lambda end"))
            ),
            param
        );
    }
