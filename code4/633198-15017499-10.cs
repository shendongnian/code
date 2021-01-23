    using System;
    namespace ConsoleApplication1
    {
      class Program
      {
        [Flags]
        enum Days
        {
            Monday    = 0,
            Tuesday   = 1,   
            Wednesday = 2, 
            Thursday  = 4, 
            Friday    = 8,   
            Saturday  = 16, 
            Sunday    = 32
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
