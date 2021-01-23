    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            // Assign first, then multiply and assign back, then print
            float f = Foo();
            f *= 100;
            Console.WriteLine((int) f); // Prints 4
            
            // Assign once, then multiply within the expression...
            f = Foo();
            Console.WriteLine((int) (f * 100)); // Prints 4
            
            Console.WriteLine((int) (Foo() * 100)); // Prints 3
        }
        
        // No need to do parsing here. We just need to get the results from a method
        static float Foo()
        {
            return 0.04f;
        }
    }
