    using System;
    namespace ConsoleApplication6
    {
        public static class ClassUtility
        {
            public static void CallOnError<TIn>(this TIn value, Func<TIn, bool> fn, Action<TIn> errorFn)
                where TIn : class
            {
                if (!fn(value))
                {
                    errorFn(value);
                }
            }
        }
        public class TestClass
        {
            public bool FirstCall(bool value)
            {
                Console.WriteLine("First call.");
                return value;
            }
            public void SecondCall()
            {
                Console.WriteLine("Second call.");
            }
            public void ThirdCall()
            {
                Console.WriteLine("Third call.");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var testClass = new TestClass();
                testClass.CallOnError(tc => tc.FirstCall(false),
                                      tc2 => tc2.SecondCall());
                testClass.CallOnError(tc => tc.FirstCall(true),
                                      tc2 => tc2.SecondCall());
                testClass.ThirdCall();
                Console.ReadLine();
            }
        }
    }
