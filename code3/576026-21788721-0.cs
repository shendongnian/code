    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class GroupByDemo
    {
        static public void Main(string[] args)
        {
            List<int> ranges = new List<int>() {100, 1000, 1000000};
    
            List<int> sizes = new List<int>(
                new int[]{99,98,10,5,5454, 12432, 11, 12432, 992, 56, 222});
    
            var sizesByRange =
                sizes.GroupBy(size => ranges.First(range => range >= size));
    
            // Pretty-print the 'GroupBy' results.
            foreach (var range in sizesByRange.OrderBy(r => r.Key))
            {
                Console.WriteLine("Sizes up to range limit '{0}':", range.Key);
    
                foreach (var size in range.ToList().OrderBy(s => s))
                {
                    Console.WriteLine("  {0}", size);
                }
            }
            Console.WriteLine("--");
        }
    }
