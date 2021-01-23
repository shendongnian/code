    private static object GetValueOfExpression<T>(T target, Expression exp)
    {
        if (exp == null)
        {
            return null;
        }
        else if (exp.NodeType == ExpressionType.Parameter)
        {
            return target;
        }
        else if (exp.NodeType == ExpressionType.Constant)
        {
            return ((ConstantExpression) exp).Value;
        }
        else if (exp.NodeType == ExpressionType.Lambda)
        {
            return exp;
        }
        else if (exp.NodeType == ExpressionType.MemberAccess)
        {
            var memberExpression = (MemberExpression) exp;
            var parentValue = GetValueOfExpression(target, memberExpression.Expression);
            if (parentValue == null)
            {
                return null;
            }
            else
            {
                if (memberExpression.Member is PropertyInfo)
                    return ((PropertyInfo) memberExpression.Member).GetValue(parentValue, null);
                else
                    return ((FieldInfo) memberExpression.Member).GetValue(parentValue);
            }
        }
        else if (exp.NodeType == ExpressionType.Call)
        {
            var methodCallExpression = (MethodCallExpression) exp;
            var parentValue = GetValueOfExpression(target, methodCallExpression.Object);
            if (parentValue == null && !methodCallExpression.Method.IsStatic)
            {
                return null;
            }
            else
            {
                var arguments = methodCallExpression.Arguments.Select(a => GetValueOfExpression(target, a)).ToArray();
                // Required for comverting expression parameters to delegate calls
                var parameters = methodCallExpression.Method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (typeof(Delegate).IsAssignableFrom(parameters[i].ParameterType))
                    {
                        arguments[i] = ((LambdaExpression) arguments[i]).Compile();
                    }
                }
                if (arguments.Length > 0 && arguments[0] == null && methodCallExpression.Method.IsStatic &&
                    methodCallExpression.Method.IsDefined(typeof(ExtensionAttribute), false)) // extension method
                {
                    return null;
                }
                else
                {
                    return methodCallExpression.Method.Invoke(parentValue, arguments);
                }
            }
        }
        else
        {
            throw new ArgumentException(
                string.Format("Expression type '{0}' is invalid for member invoking.", exp.NodeType));
        }
    }
