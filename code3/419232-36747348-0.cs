    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SpliceExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
                List<int> subset = numbers.Splice(3, 3);
    
                Console.WriteLine(String.Join(", ", numbers)); // Prints 1, 2, 3, 7, 8, 9
                Console.WriteLine(String.Join(", ", subset));  // Prints 4, 5, 6
    
                Console.ReadLine();
            }
        }
    
      static class MyExtensions
      {
          public static List<T> Splice<T>(this List<T> list, int index, int count)
          {
              List<T> range = list.GetRange(index, count);
              list.RemoveRange(index, count);
              return range;
          }
      }
    }
