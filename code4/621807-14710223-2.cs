    public class NullChecker where T : class
    {
        public static bool IsNotNull<T>(default(T) type)
        {
            return type != null;
        }
    }
