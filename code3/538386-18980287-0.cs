    using System;
    using System.Linq;
    
    namespace SortTest
    {
      static class Program
      {
        static void Main()
        {
          var arr = new[] { new { Name = "Mary", Age = 17, }, new { Name = "Louise", Age = 17, }, };
    
          Array.Sort(arr, (x, y) => x.Age.CompareTo(y.Age));
    
          Console.WriteLine(string.Join(",", arr.Select(x => x.Name)));
        }
      }
    }
