    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        internal static class Program
        {
            private static void Main(string[] args)
            {
                string[] array  = new []{"One", "Two", "Three", "Four"};
                array.Print();
                Console.WriteLine();
                object[] objArray = new object[] {"One", 2, 3.3, TimeSpan.FromDays(4), '5', 6.6f, 7.7m};
                objArray.Print();
            }
        }
        public static class MyEnumerableExt
        {
            public static void Print(this IEnumerable<object> @this)
            {
                foreach (var obj in @this)
                    Console.WriteLine(obj);
            }
        }
    }
