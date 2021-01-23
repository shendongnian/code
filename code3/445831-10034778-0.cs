    public class SomeClass<TParam, TReturn>
    {
        private Func<TParam, TReturn> _callback;
        public class SomeClass(Func<TParam, TReturn> callback)
        {
            _callback = callback;
        }
    }
