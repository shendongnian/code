    var helloWorldBlock =
        Expression.Block(
            new ParameterExpression[] {stringBuilderParam},
            new Expression[]
                {
                    Expression.Assign(
                        stringBuilderParam,
                        Expression.New(typeof (StringBuilder))),
                    Expression.Call(
                        stringBuilderParam,
                        typeof (StringBuilder).GetMethod(
                            "Append",
                            new[] {typeof (string)}),
                        new Expression[]
                            {
                                Expression.Constant(
                                    "Helloworld", typeof (string))
                            }),
                    Expression.Call(
                        stringBuilderParam,
                        "ToString",
                        new Type[0],
                        new Expression[0])
                });
