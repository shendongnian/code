    using System;
    
    class Bar
    {
        ~Bar() { Console.WriteLine("Finalized!"); }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Bar bar = new Bar();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
