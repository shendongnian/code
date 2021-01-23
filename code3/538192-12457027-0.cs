     public static class PropertyHelper
        {
            public static string GetName<T>(Expression<Func<T>> e)
            {
                var member = (MemberExpression)e.Body;
                return member.Member.Name;
            }
    
            public static Type GetPropertyType<T>(Expression<Func<T>> e)
            {
                var member = (MemberExpression)e.Body;
                return member.Type;
            }
        }
