            ParameterExpression x = Expression.Parameter(typeof (object), "x");
            ConditionalExpression body = Expression.IfThenElse(
                Expression.Constant(true),
                Expression.Constant("Cash"),
                Expression.Constant(" ")
                );
            LabelCriteria = Expression.Lambda<Func<object, string>>(body, x);
