    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            double d1 = 0.1;        
            double d2 = 0.2;
            Console.WriteLine(DoubleConverter.ToExactString(d1 + d2));
            Console.WriteLine(DoubleConverter.ToExactString(0.3));
        }
    }
