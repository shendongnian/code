    using System;
    namespace ConsoleApplication1
    {
        public sealed class MyClass
        {
            int Add(int x, int y)
            {
                return x + y;
            }
        }
        public static class MyClassExtensions
        {
            public static decimal Average(this MyClass value, int x, int y)
            {
                return (x + y) / 2M;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var myClass = new MyClass();
                var avg = myClass.Average(10, 20);
                Console.WriteLine(avg);
                Console.ReadLine();
            }
        }
    }
