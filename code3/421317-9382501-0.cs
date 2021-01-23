    using System.Linq.Expressions;
    using System.Reflection;
    public static class MethodInfoHelper
    {
        public static MethodInfo GetMethodInfo<T>(Expression<Action<T>> expression)
        {
            var member = expression.Body as MethodCallExpression;
            if (member != null)
                return member.Method;
            throw new ArgumentException("Expression is not a method", "expression");
        }
    }
