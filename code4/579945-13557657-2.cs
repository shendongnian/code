    static class MyClass<T>
    {
        public static void DoWork<T>(T t)
        {
        }
    }
    
    static class MyInvoker
    {
        public static void DoWork<T>(T t)
        {
            MyClass<T>.DoWork(t);
        }
    }
