    public struct MaybeMonad<T> where T : class
    {
        private readonly T _value;
     
        public MaybeMonad(T value)
        {
            _value = value;
        }
     
        public MaybeMonad<TResult> Select<TResult>(Func<T, TResult> getter)
            where TResult : class
        {
            var result = (_value == null) ? null : getter(_value);
            return new MaybeMonad<TResult>(result);
        }  
     
        public TResult Select<TResult>(Func<T, TResult> getter,
                                       TResult alternative)
        {
            return (_value == null) ? alternative : getter(_value);
        }
     
        public void Do(Action<T> action)
        {
            if (_value != null)
                action(_value);
        }
    }
    public static class Maybe
    {
        public static MaybeMonad<T> From<T>(T value) where T : class
        {
            return new MaybeMonad<T>(value);
        }
    }
    
    public static class MaybeMonadExtensions
    {
        public static MaybeMonad<T> Maybe<T>(this T value) where T : class
        {
            return new MaybeMonad<T>(value);
        }
    }
