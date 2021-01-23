    var type1 = new Type1();
    var type2 = new Type2();
    ...
    var propMap = new List<Tuple<Expression<Func<Type1, object>>, Expression<Func<TradeStaticAttributesItemModel, object>>>>
        {
            new Tuple<Expression<Func<Type1, object>>, Expression<Func<Type2, object>>>(x => x.Prop1, x => x.Prop1),
            new Tuple<Expression<Func<Type1, object>>, Expression<Func<Type2, object>>>(x => x.Prop2, x => x.Prop2)
        };
    foreach (var prop in propMap)
    {
        if (prop.Item1.Compile()(type1) != prop.Item2.Compile()(type2))
        {
            ParameterExpression valueParameterExpression = Expression.Parameter(typeof(object));
            // This handles nullable types
            Expression targetExpression = prop.Item1.Body is UnaryExpression ? ((UnaryExpression)prop.Item1.Body).Operand : prop.Item1.Body;
            var assign = Expression.Lambda<Action<Type1, object>>(
                Expression.Assign(targetExpression, Expression.Convert(valueParameterExpression, targetExpression.Type)),
                prop.Item1.Parameters.Single(),
                valueParameterExpression);
            Action<Type1, object> setter = assign.Compile();
            setter(type1, prop.Item2.Compile()(type2));
        }
    }
