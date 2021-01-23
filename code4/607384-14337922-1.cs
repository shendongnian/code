    public static class AttributeUtils
    {
        public static bool HasAttribute<TAttribute>(this MemberInfo member, bool inherit = true)
            where TAttribute : Attribute
        {
            return member.IsDefined(typeof(TAttribute), inherit);
        }
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo member, bool inherit = true)
            where TAttribute : Attribute
        {
            return member.GetAttributes<TAttribute>(inherit).FirstOrDefault();
        }
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo member, bool inherit = true)
            where TAttribute : Attribute
        {
            return member.GetCustomAttributes(typeof(TAttribute), inherit).Cast<TAttribute>();
        }
    }
    public class MethodOf<T>
    {
        public MethodOf(T func)
        {
            var del = func as Delegate;
            if (del == null) throw new ArgumentException("Cannot convert func to Delegate.", "func");
            Method = del.Method;
        }
        private MethodInfo Method { get; set; }
        public static implicit operator MethodOf<T>(T func)
        {
            return new MethodOf<T>(func);
        }
        public static implicit operator MethodInfo(MethodOf<T> methodOf)
        {
            return methodOf.Method;
        }
    }
