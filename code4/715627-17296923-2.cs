    using System;
    namespace posneg
    {
        class Program
        {
            static void Main(string[] args)
            {
                int num = Int32.Parse(args[0]);
    
                Console.WriteLine(( num + ( num / Math.Abs(num) )));
    
            }
        }
    }
