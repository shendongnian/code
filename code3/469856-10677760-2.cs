    public static class Ex
    {
        public static void EnsureNotNull<T>(this T t, string argName) where T:class
        {
            if(t == null)
            {
                throw new ArgumentNullException(argName);
            }
        }
    }
