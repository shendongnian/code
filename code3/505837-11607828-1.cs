    using System;
    using System.Linq;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list1 = Enumerable.Range(0, 10).ToList();
                var list2 = Enumerable.Range(10, 10).ToList();
                list1.AddRange(list2);
    
                list1.ForEach(Console.WriteLine);
    
                Console.ReadLine();
            }
        }
    }
