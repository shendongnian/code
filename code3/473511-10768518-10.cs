    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace WpfApplication
    {
        public static class ReflectionHelper
        {
            public static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> getter)
            {
                return (PropertyInfo)((MemberExpression)getter.Body).Member;
            }
        }
    }
