    using System;
    using System.Dynamic;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                dynamic expando = new ExpandoObject();
                expando.Name = "Name";  // Add property at run-time.
                expando.PrintName = (Action) (() => Console.WriteLine(expando.Name)); // Add method at run-time.
                test(expando);
            }
            private static void test(dynamic expando)
            {
                expando.PrintName();
            }
        }
    }
