    using System;
    
    namespace GenericsDelegates
    {
        class Program
        {
            static void Main(string[] args)
            {
                string test1 = ExceptionalMethod(TestMethod1, "test");
                string test2 = ExceptionalMethod(TestMethod2, "test");
    
                Console.WriteLine(test1);
                Console.WriteLine(test2);
            }
    
            public static TResult ExceptionalMethod<T, TResult>(Func<T, TResult> func, T param)
            {
                return func(param);
            }
    
            public static string TestMethod1(string param)
            {
                return "TestMethod1-" + param;
            }
    
            public static string TestMethod2(string param)
            {
                return "TestMethod2-" + param;
            }
        }
    }
