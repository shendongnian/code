    public LambdaExpression GetOuterLambda()
    {
        ...
        //Delegate compiledInnerLambda = GetInnerLambda().Compile();
        //LambdaWrapper wrapper = new LambdaWrapper(compiledInnerLambda);
        lambdaBody.Add(Expression.New(
            typeof(LambdaWrapper).GetConstructor(new[] { typeof(Delegate) }),
            Expression.Call(
                Expression.Call(
                    typeof(ForSO).GetMethod("GetInnerLambda", BindingFlags.Public | BindingFlags.Static),
                    Param
                ),
                typeof(LambdaExpression).GetMethod("Compile", Type.EmptyTypes)
            )
        ));
        ...
    }
    public static LambdaExpression GetInnerLambda(object param)
    {
        return Expression.Lambda(
            Expression.Block(
                Expression.Call(null,
                    typeof(ForSO).GetMethod("Write"),
                    Expression.Constant("Inner lambda start")),
                Expression.Call(null,
                    typeof(ForSO).GetMethod("Write"),
                    Expression.Constant(param)),
                Expression.Call(null,
                    typeof(ForSO).GetMethod("Write"),
                    Expression.Constant("Inner lambda end"))
            )
        );
    }
