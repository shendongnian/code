    namespace ConsoleApplication1
    {
      using System;
    
      public class Program
      {
        public static void Main()
        {
          const int Number = 123456789;
          var formatted = string.Format("{0:#,###0}", Number);
          
          Console.WriteLine(formatted);
          Console.ReadLine();
        }
      }
    }
