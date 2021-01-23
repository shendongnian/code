    public static class ObjectExtensions
    {
        public static MemberInfo GetMember<T,R>(this T instance, 
             Expression<Func<T, R>> selector)
        {
            var member = selector.Body as MemberExpression;
            if (member != null)
            {
                return member.Member;
            }
            return null;
        }
    
        public static T GetAttribute<T>(this MemberInfo meminfo) where T : Attribute
        {
           return meminfo.GetCustomAttributes(typeof(T)).FirstOrDefault() as T;
        }
    }
