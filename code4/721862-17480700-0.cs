    public static class IfNotNullExtensionMethod
    {
        public static U IfNotNull<T, U>(this T t, Func<T, U> fn)
        {
            return t != null ? fn(t) : default(U);
        }
    }
