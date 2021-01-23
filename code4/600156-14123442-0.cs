    using System;
    using System.Linq;
    
    namespace Stackoverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                DumpResult(new string[] { });
                DumpResult(new string[] { "Apple" });
                DumpResult(new string[] { "Apple", "Banana" });
                DumpResult(new string[] { "Apple", "Banana", "Pear" });
            }
    
            private static void DumpResult(string[] someStringArray)
            {
                string result = string.Join(", ", someStringArray.Take(someStringArray.Length - 1)) + (someStringArray.Length <= 1 ? "" : " and ") + someStringArray.LastOrDefault();
                Console.WriteLine(result);
            }
        }
    }
