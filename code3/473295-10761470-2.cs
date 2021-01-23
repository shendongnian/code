    using System;
    using System.Collections.Generic;
    
        static class Program
        {
          static void Main()
          {
            Dictionary<string, int> theDictionary = new Dictionary<string, int>(StringComparer.Ordinal);
            theDictionary.Add("First", 1);
            bool exists = theDictionary.ContainsKey("FIRST");
          
            Console.WriteLine(exists);
          }
        }
