    using System;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                bool result = false;
                Tracing.Log(() =>
                {
                    result = test("");  // Assign to result.
                }, "Message");
                Console.WriteLine(result);
            }
            private static bool test(string value)
            {
                return string.IsNullOrEmpty(value);
            }
        }
        public static class Tracing
        {
            public static void Log(Action action, string message)
            {
                action();
                Console.WriteLine(message);
            }
        }
    }
                        
