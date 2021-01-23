    namespace CSharp
    {
      using System;
      using System.Collections.Generic;
      using System.Linq;
    
      class Cat
      {
        public string Name { get; set; }
      }
    
      class Program
      {
        private static void Main()
        {
          var cats = new List<Cat>();
    
          for (int i = 0; i < 100; ++i)
          {
            cats.Add(new Cat());
          }
    
          cats.AsParallel().ForAll(cat => cat.Name = "Carlo");
    
          foreach (var cat in cats)
          {
            Console.WriteLine(cat.Name);
          }
    
          Console.ReadLine();
        }
      }
    }
