    class Program
    {
        static void Main(string[] args)
        {
            var bar = MyClass<int, string, string>.ConvertFunction(Test);
            Console.WriteLine("Invoking {0} {1}","Test(10,\"abc\")", Test(10, "abc") );
            Console.WriteLine("Invoking {0} {1}","bar.Invoke(\"abc\",10)", bar.Invoke("abc", 10) );
        }
        private static string Test(int arg1, string arg2)
        {
            return String.Format("First arg = {0}, second arg = {1}. Or is it...?",arg1,arg2);
        }
    }
    class MyClass<T1, T2, TResult>
    {
        static Func<T1, T2, TResult> _foo;
        public static Func<T2, T1, TResult> ConvertFunction(Func<T1, T2, TResult> foo)
        {
            _foo = foo;
            return new Func<T2, T1, TResult>(MyFunc);
        }
        private static TResult MyFunc(T1 arg1, T2 arg2)
        {
            return _foo(arg1, arg2);
        }
        private static TResult MyFunc(T2 arg2, T1 arg1)
        {
            return MyFunc(arg1, arg2);
        }
    }
