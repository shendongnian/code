    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            public const long Iterations = (long)1e8;
            static void Main()
            {
                var list = new List<int>() { 1 };
                var array = new int[1];
                array[0] = 1;
                var results = new Dictionary<string, TimeSpan>();
                results.Add("int[]", Benchmark(array, Iterations));
                results.Add("List<int>", Benchmark(list, Iterations));
                Console.WriteLine("Function".PadRight(30) + "Count()");
                foreach (var result in results)
                {
                    Console.WriteLine("{0}{1}", result.Key.PadRight(30), Math.Round(result.Value.TotalSeconds, 3));
                }
                Console.ReadLine();
            }
            public static TimeSpan Benchmark(IEnumerable<int> source, long iterations)
            {
                var countWatch = new Stopwatch();
                countWatch.Start();
                for (long i = 0; i < iterations; i++) Count(source);
                countWatch.Stop();
                return countWatch.Elapsed;
            }
            public static int Count<TSource>(IEnumerable<TSource> source)
            {
                ICollection<TSource> is2 = source as ICollection<TSource>;
                if (is2 != null)
                    return is2.Count;  // This is executed for int[] AND List<int>.
                ICollection is3 = source as ICollection;
                if (is3 != null)
                    return is3.Count;
            
                int num = 0;
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                        num++;
                }
                return num;
            }
        }
    }
