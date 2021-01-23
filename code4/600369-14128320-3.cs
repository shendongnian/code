    using System;
    using System.Linq;
    
    internal class Program
    {
      private static void Main(string[] args)
      {
        Enumerable.Range(0, Int32.MaxValue)
          .Select(i => Int32.TryParse(Console.ReadLine(), out i) ? i : -1)
          .Where(i => i >= 0)
          .TakeWhile(i => i > 0)
          .Select(i => {
             Console.WriteLine(String.Join("", Enumerable.Repeat("|", i)));
             return 0;})
          .Count();
      }
    }
