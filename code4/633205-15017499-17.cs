    using System;
    namespace ConsoleApplication1
    {
      class Program
      {
        [Flags]
        enum Days
        {
            Monday    = 1,
            Tuesday   = 2,   
            Wednesday = 4, 
            Thursday  = 8, 
            Friday    = 16,   
            Saturday  = 32, 
            Sunday    = 64
        };
        static void Main(string[] args)
        {
            Days holidays = Days.Sunday | Days.Saturday;
            if ((Days.Sunday | holidays) == holidays)
                Console.WriteLine("Sunday is a Holiday");
            else
                Console.WriteLine("Sunday is a Holiday");
            if ((Days.Tuesday | holidays) == holidays)
                Console.WriteLine("Tuesday is not a Holiday");
            else
                Console.WriteLine("Tuesday is not a Holiday");
            Console.ReadKey();
        }
      }
    }
