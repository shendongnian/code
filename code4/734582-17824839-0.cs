    using System;
    class Runner
    {
        static void Main()
        {
            A a = new A();
            // how to say a.PrintStuff() without a 'using'
            Console.Read();
        }
    }
    class A { }
    namespace System
    {
        static class AExtensions
        {
            public static void PrintStuff(this A a)
            {
                Console.WriteLine("text");
            }
        }
    }
