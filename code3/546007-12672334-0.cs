    public struct SomeType<T> where T : IConvertible
    {
        private static readonly T _one = (T)Convert.ChangeType(1, typeof(T));
        public static T One { get { return _one; } }
    }
