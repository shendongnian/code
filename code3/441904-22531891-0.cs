    public static Expression CreateSetValueExpression(Expression target, Expression value, FieldInfo fieldInfo)
    {
        // workaround for readonly fields: use reflection, this is a lot slower but the only way except using il directly
        if (fieldInfo.IsInitOnly)
        {
            MethodInfo fieldInfoSetValueMethod = typeof(FieldInfo).GetMethod("SetValue", new[] { typeof(object), typeof(object) }); 
            return Expression.Call(Expression.Constant(fieldInfo), fieldInfoSetValueMethod, target, Expression.Convert(value, typeof(object)));
        }
        return Expression.Assign(Expression.Field(target, fieldInfo), value);
    }
