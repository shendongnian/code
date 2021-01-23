    using System;
    using System.Linq;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] array = new int[10];
                array[0] = 1;
                array[1] = 1;
                array[2] = 1;
                array[3] = 2;
                array[4] = 1;
                array[5] = 2;
                array[6] = 1;
                array[7] = 1;
                array[8] = 2;
                array[9] = 3;
    
                var group = from i in array
                            group i by i into g
                            select new
                            {
                                g.Key,
                                Sum = g.Count()
                            };
    
                foreach (var g in group)
                {
                    Console.WriteLine(g.Key + " " + g.Sum);
                }
            }
        }
    }
