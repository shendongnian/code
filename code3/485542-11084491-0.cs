    static Action<object, object> FormAction(FieldInfo fieldInfo)
    {
        ParameterExpression obj = Expression.Parameter(typeof(object), fieldInfo.Name);
        ParameterExpression value = Expression.Parameter(typeof(object));
        MemberExpression fieldExp = Expression.Field(Expression.Convert(obj, fieldInfo.DeclaringType), fieldInfo.Name);
        BinaryExpression assignExp = Expression.Assign(fieldExp, Expression.Convert(value, fieldInfo.FieldType));
        return Expression.Lambda<Action<object, object>>(assignExp, obj, value).Compile();
    }
