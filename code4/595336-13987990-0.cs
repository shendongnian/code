    var predicate =
        Expression.Lambda<Func<T, bool>>(
            Expression.Call(
                Expression.Call( // <=== this one is new
                    Expression.PropertyOrField(parameter, "FirstName"),
                    "ToUpper", null),
                "Contains", null,
                Expression.Constant("myvalue".ToUpper())), parameter
            );
