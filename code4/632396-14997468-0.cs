    class MyClass<T1, T2, TResult> where TResult : new()
    {
        public MyClass()
        {
            Func<T1, T2, TResult> foo = MyFunc;
            Func<T2, T1, TResult> bar = ConvertFunction(foo);
        }
        private Func<T2, T1, TResult> ConvertFunction(Func<T1, T2, TResult> foo)
        {
            return new Func<T2, T1, TResult>(MyFunc);
        }
        private TResult MyFunc(T1 arg1, T2 arg2)
        {
            return new TResult();
        }
        private TResult MyFunc(T2 arg1, T1 arg2)
        {
            return MyFunc(arg1, arg2);
        }
    }
