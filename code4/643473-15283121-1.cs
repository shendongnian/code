    using System;
    
    class Test
    {
        static void Main()
        {
            // Prevent everything being computed at compile-time
            double zero = 0d;
            Console.WriteLine(1d / zero);  // Infinity
            Console.WriteLine(0d / zero);  // NaN
            Console.WriteLine(-1d / zero); // -Infinity
        }
    }
