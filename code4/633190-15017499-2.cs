    namespace ConsoleApplication1
    {
      class Program
      {
        [Flags]
        enum Days
        {
            Monday, //Default to 0
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
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
