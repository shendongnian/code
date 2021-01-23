    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Aggregations
    {
        class Program
        {
            static void Main(string[] args)
            {
                int maxYear = 22;
                int period = 5;
                int year = 1985;
    
                List<List<int>> aggregations = new List<List<int>>();
                int i = -1;
                for (int y = 0; y <= maxYear; y++)
                {
                    if (y % period == 0)
                    {
                        aggregations.Add(new List<int>());
                        i++;
                    }
                    aggregations.ElementAt(i).Add(year);
                    year++;
                }
                foreach ( List<int> l in aggregations )
                {
                    foreach (int yy in l)
                    {
                        Console.Write(yy + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
