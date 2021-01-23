    using System;
    namespace ConsoleApplication1
    {
        public sealed class MyClass
        {
            public int X { get; private set; }
            public int Y { get; private set; }
            public MyClass(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            int Add()
            {
                return this.X + this.Y;
            }
        }
        public static class MyClassExtensions
        {
            public static decimal Average(this MyClass value)
            {
                return (value.X + value.Y) / 2M;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var myClass = new MyClass(10, 20);
                var avg = myClass.Average();
                Console.WriteLine(avg);
                Console.ReadLine();
            }
        }
    }
