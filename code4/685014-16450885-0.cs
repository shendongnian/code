    public static class MyCustomExtensions
    {
        public static bool IsFoo1(IList<T> value, T other)
            where T : IList<T>
        {
            // ...
        }
        public static bool IsFoo2(T value, T other)
            where T : IList<T>
        {
            // ...
        }
    }
