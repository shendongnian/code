    using System;
    using System.Collections.Generic;
    
    
    namespace ConsoleApplication2
    {
      public class Program
      {
        public IList<int> GenerateFibonacci(int toIndex)
        {
    
          IList<int> sequence = new List<int>();
    
          sequence.Add(0);
    
          sequence.Add(1);
    
          for (int i = 0; i < toIndex; i++)
          {
    
            sequence.Add(sequence[i]+ sequence[i + 1]);
    
          }
    
          return sequence;
    
        }
    
        static void Main()
        {
          var s = GenerateFibonacci(10);     
          Console.ReadKey();
        }
      }
    }
