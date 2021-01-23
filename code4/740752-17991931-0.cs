    using System;
    
    class Test
    {
        static void Main()
        {
            var input = 1.111111111111111111111111111m;
            for (int i = 1; i < 10; i++)
            {
                decimal output = input * (decimal) i;
                Console.WriteLine(output);
            }
        }
    }
