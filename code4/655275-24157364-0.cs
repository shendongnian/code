    public static class ReflectionHelper
    {
        public static TAttr GetAttribute<TClass, TProp, TAttr>(Expression<Func<TClass, TProp>> selector) where TAttr : Attribute
        {
            var member = selector.Body as MemberExpression;
            return member.Member.GetCustomAttributes<TAttr>(false).First();
        }
    }
