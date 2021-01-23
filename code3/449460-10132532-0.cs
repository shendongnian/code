    using System;
    
    public class Test
    {
        static void Main()
        {
            PrintResult(1, 2);      // Prints 0
            PrintResult(1.0, 2.0);  // Prints 0.5
        }
        
        static void PrintResult(dynamic x, dynamic y)
        {
            Console.WriteLine(x / y);
        }
    }
