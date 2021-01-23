    using System;
    
    class Test
    {
        static void Main()
        {
            string input = "x/u00y";
            string output = input.Replace("/u00", @"\u00");
            Console.WriteLine(output); // Result: x\u00y
        }
    }
