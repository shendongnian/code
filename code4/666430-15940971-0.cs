    public static class GenericHelper
    {
        public static object Invoke(Expression<Action> invokeMethod, object target, Type genericType, params object[] parameters)
        {
            MethodInfo methodInfo = ParseMethodExpression(invokeMethod);
            if (!methodInfo.DeclaringType.IsGenericType)
                throw new ArgumentException("The method supports only generic types");
            Type type = methodInfo.DeclaringType.GetGenericTypeDefinition().MakeGenericType(genericType);
            MethodInfo method = type.GetMethod(methodInfo.Name);
            return method.Invoke(target, parameters);
        }
        public static object Invoke(Expression<Action> invokeMethod, Type genericType, params object[] parameters)
        {
            return Invoke(invokeMethod, null, genericType, parameters: parameters);
        }
        private static MethodInfo ParseMethodExpression(LambdaExpression expression)
        {
            Validate.ArgumentNotNull(expression, "expression");
            // Get the last element of the include path
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                var memberExpression = unaryExpression.Operand as MethodCallExpression;
                if (memberExpression != null)
                    return memberExpression.Method;
            }
            var expressionBody = expression.Body as MethodCallExpression;
            if (expressionBody != null)
                return expressionBody.Method;
            throw new NotSupportedException("Expession not supported");
        }
    }
