    Expression.Lambda<Action<int>>(
        Expression.Block(
            this.TheExpression,
            Expression.Label(returnTarget)
        ),
        new ParameterExpression[] { para }
        ).Compile()(5);
