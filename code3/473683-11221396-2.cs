    public static class ExceptionalMonadExtensions
    {
        public static Exceptional<T> ToExceptional<T>(this T value)
        {
            return new Exceptional<T>(value);
        }
        public static Exceptional<T> ToExceptional<T>(this Func<T> getValue)
        {
            return new Exceptional<T>(getValue);
        }
        public static Exceptional<U> SelectMany<T, U>(this Exceptional<T> value, Func<T, Exceptional<U>> k)
        {
            return (value.HasException)
                ? new Exceptional<U>(value.Exception)
                : k(value.Value);
        }
        public static Exceptional<V> SelectMany<T, U, V>(this Exceptional<T> value, Func<T, Exceptional<U>> k, Func<T, U, V> m)
        {
            return value.SelectMany(t => k(t).SelectMany(u => m(t, u).ToExceptional()));
        }
    }
