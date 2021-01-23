    public static partial class IConvertibleExtensionMethods
    {
        public static T To<T>(this IConvertible self)
        {
            return (T)Convert.ChangeType(self, typeof(T));
        }   // eo To<T>
    }   // eo class IConvertibleExtensionMethods
