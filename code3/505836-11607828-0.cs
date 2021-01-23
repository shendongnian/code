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
                var list3 = list1.Concat(list2).ToList();
    
                list3.ForEach(Console.WriteLine);
    
                Console.ReadLine();
            }
        }
    }
