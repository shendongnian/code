    public static class Exceptional
    {
        public static Exceptional<T> From<T>(T value)
        {
            return value.ToExceptional();
        }
        public static Exceptional<T> Execute<T>(Func<T> getValue)
        {
            return getValue.ToExceptional();
        }
    }
    
    public static class ExceptionalExtensions
    {
        public static Exceptional<U> ThenExecute<T, U>(this Exceptional<T> value, Func<T, U> getValue)
        {
            return value.SelectMany(x => Exceptional.Execute(() => getValue(x)));
        }
    }
