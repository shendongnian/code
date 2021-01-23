    ComplexObj obj = new ComplexObj();
    Expression<Func<ComplexObj, object>> expression = obj => obj.Contacts[index].FirstName;
    obj.AssignNewValue(expression, firstName);
    public static void AssignNewValue(this ComplexObj obj, Expression<Func<ComplexObj, object>> expression, object value)
    {
        ParameterExpression valueParameterExpression = Expression.Parameter(typeof(object));
        Expression targetExpression = expression.Body is UnaryExpression ? ((UnaryExpression)expression.Body).Operand : expression.Body;
        var newValue = Expression.Parameter(expression.Body.Type);
        var assign = Expression.Lambda<Action<ComplexObj, object>>
                    (
                        Expression.Assign(targetExpression, Expression.Convert(valueParameterExpression, targetExpression.Type)),
                        expression.Parameters.Single(),
                        valueParameterExpression
                    );
        assign.Compile().Invoke(obj, value);
    }
