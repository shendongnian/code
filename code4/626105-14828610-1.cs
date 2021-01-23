    var body =
        Expression.AndAlso(
            Expression.Not(
                Expression.Call(typeof(string), "IsNullOrWhiteSpace", null,
                                                           parameterProperty)
            ),
            Expression.Equal(
                Expression.Call(parameterProperty, "ToLower", null),
                Expression.Constant("name of counterparty")
            )
        );
