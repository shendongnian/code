    class MyFuncConverter<T1, T2, TResult>
    {
        static Func<T1, T2, TResult> _foo;
        public static Func<T2, T1, TResult> ConvertFunction(Func<T1, T2, TResult> foo)
        {
            _foo = foo;
            return new Func<T2, T1, TResult>(MyFunc);
        }
        private static TResult MyFunc(T2 arg2, T1 arg1)
        {
            return _foo(arg1, arg2);
        }
    }
