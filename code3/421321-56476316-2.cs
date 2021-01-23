    public static class GetIndirectMethodInfoUtil
    {
        // Get MethodInfo from Lambda expressions
        public static MethodInfo GetIndirectMethodInfo(Expression<Action> expression) 
            => GetIndirectMethodInfo((LambdaExpression)expression);
        public static MethodInfo GetIndirectMethodInfo<T>(Expression<Action<T>> expression) 
            => GetIndirectMethodInfo((LambdaExpression)expression);
        public static MethodInfo GetIndirectMethodInfo<T, TResult>(Expression<Func<TResult>> expression) 
            => GetIndirectMethodInfo((LambdaExpression)expression);
        public static MethodInfo GetIndirectMethodInfo<T, TResult>(Expression<Func<T, TResult>> expression) 
            => GetIndirectMethodInfo((LambdaExpression)expression);
        // Used by the above
        private static MethodInfo GetIndirectMethodInfo(LambdaExpression expression)
        {
            if (!(expression.Body is MethodCallExpression methodCall))
            {
                throw new ArgumentException(
                    $"Invalid Expression ({expression.Body}). Expression should consist of a method call only.");
            }
            return methodCall.Method;
        }
    }
