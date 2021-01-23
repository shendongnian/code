        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int arrsize = 1000000;
                Random rnd = new Random(42);
                string[] arr1 = new string[arrsize];
                string[] arr2 = new string[arrsize];
                for (int i = 0; i < arrsize; i++)
                {
                    arr1[i] = rnd.Next().ToString();
                    arr2[i] = rnd.Next().ToString();
                }
                {
                    var stamp = (System.Diagnostics.Stopwatch.GetTimestamp());
                    arr1.Intersect(arr2).Count();
                    Console.WriteLine("array" + (System.Diagnostics.Stopwatch.GetTimestamp() - stamp));
                }
            {
            
                HashSet<string> set = new HashSet<string>(arr1);
                var stamp = (System.Diagnostics.Stopwatch.GetTimestamp());
                set.IntersectWith(arr2);
                int count = set.Count;
                Console.WriteLine("HashSet" + (System.Diagnostics.Stopwatch.GetTimestamp() - stamp));
            }
                {
                   var stamp = (System.Diagnostics.Stopwatch.GetTimestamp());
                    HashSet<string> set = new HashSet<string>(arr1);
                    set.IntersectWith(arr2);
                    int count = set.Count;
                    Console.WriteLine("HashSet + new" + (System.Diagnostics.Stopwatch.GetTimestamp() - stamp));
                }
               
                {
                    var stamp = (System.Diagnostics.Stopwatch.GetTimestamp());
                    SortedSet<string> set = new SortedSet<string>(arr1);
                    set.IntersectWith(arr2);
                    int count = set.Count;
                    Console.WriteLine("SortedSet +new " + (System.Diagnostics.Stopwatch.GetTimestamp() - stamp));
                }
    
                {
                    
                    SortedSet<string> set = new SortedSet<string>(arr1);
                    var stamp = (System.Diagnostics.Stopwatch.GetTimestamp());
                    set.IntersectWith(arr2);
                    int count = set.Count;
                    Console.WriteLine("SortedSet without new " + (System.Diagnostics.Stopwatch.GetTimestamp() - stamp));
                }
            }
        }
    }
