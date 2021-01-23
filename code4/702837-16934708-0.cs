    namespace ConsoleApplication4
    {
      using System;
      using System.Collections.Generic;
      using System.Linq;
    
      public class Holder
      {
        public const int Number1 = 7;
    
        public const int Number2 = 17;
    
        public const int Number3 = 42;
    
        public static IEnumerable<int> AllNumbers()
        {
          return
            typeof(Holder).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
                          .Where(p => p.FieldType == typeof(int))
                          .Select(p => (int)p.GetValue(null));
        }
    
        public static int RandomNumber(Random r)
        {
          var possibleNumbers = AllNumbers().ToList();
    
          var draw = r.Next(possibleNumbers.Count);
    
          return possibleNumbers[draw];
        }
      }
    
      public class Program
      {
        public static void Main()
        {
          var r = new Random();
    
          for (int i = 0; i < 10; i++)
          {
            Console.WriteLine(Holder.RandomNumber(r));
          }
    
          Console.WriteLine("Done");
          Console.ReadLine();
        }
      }
    }
