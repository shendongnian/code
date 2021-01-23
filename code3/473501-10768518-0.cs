    public static class ReflectionHelper
    {
        public static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> getter)
        {
            return (PropertyInfo)((MemberExpression)getter.Body).Member;
        }
    }
