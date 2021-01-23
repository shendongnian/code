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
    
        public static AT GetAttribute<AT, T, R>(this T instance, 
             Expression<Func<T, R>> selector) where AT : Attribute
        {
           var meminfo = GetMember(instance, selector);
           return meminfo.GetCustomAttributes(typeof(AT)).FirstOrDefault() as AT;
        }
    }
