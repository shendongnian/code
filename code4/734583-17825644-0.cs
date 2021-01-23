    A.cs:
    using System;
    namespace ANamespace
    {
    
         class A { }
    }
    
    AExtensions.cs:
    namespace ANamespace
    {
        static class AExtensions
        {
            public static void PrintStuff(this A a)
            {
                Console.WriteLine("text");
            }
        }
    }
