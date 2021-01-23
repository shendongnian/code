    public static class ReflectionExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this ICustomAttributeProvider obj, bool inherit)
            where TAttribute : Attribute
        {
            return obj.GetAttributes<TAttribute>(inherit).FirstOrDefault();
        }
        public static TAttribute[] GetAttributes<TAttribute>(this ICustomAttributeProvider obj, bool inherit)
            where TAttribute : Attribute
        {
            return obj.GetCustomAttributes(typeof (TAttribute), inherit).Cast<TAttribute>().ToArray();
        }
        public static bool HasAttribute<TAttribute>(this ICustomAttributeProvider obj, bool inherit)
            where TAttribute : Attribute
        {
            return obj.GetAttributes<TAttribute>(inherit).Any();
        }
    }
