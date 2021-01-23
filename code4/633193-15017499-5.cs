    using System;
    namespace ConsoleApplication1
    {
      class Program
      {
        [Flags]
        enum Days
        {
            Monday,     //Default 0
            Tuesday,    //Default 1
            Wednesday,  //Default 3
            Thursday,   //Default 4
            Friday,     //Default 5
            Saturday,   //Default 6
            Sunday      //Default 7
        };
        static void Main(string[] args)
        {
            Days holidays = Days.Sunday | Days.Saturday;
            if ((Days.Sunday | holidays) == Days.Sunday) // This returns true. Why ?
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            Console.ReadKey();
        }
      }
    }
