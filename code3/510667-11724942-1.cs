    using Kreativ.Application.One;
    using System;
    namespace Kreativ.Application.Two
    {
        public class MainClass
        {
            public static void Main()
            {
                int i = SomeClass.GetSomeResult();
                Console.WriteLine(i);
            }
        }
    }
