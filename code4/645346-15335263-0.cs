    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        internal static class Program
        {
            public static void Main()
            {
                double[] test = new double[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
                foreach (var pair in test.AsPairs()) // This is how you use it.
                {
                    Console.WriteLine("({0}, {1})", pair.Item1, pair.Item2);
                    // Or simply: Console.WriteLine(pair);
                }
            }
        }
        public static class EnumerableExt
        {
            public static IEnumerable<Tuple<T, T>> AsPairs<T>(this IEnumerable<T> sequence)
            {
                bool isFirst = true;
                T first = default(T);
                foreach (var item in sequence)
                {
                    if (isFirst)
                    {
                        first = item;
                        isFirst = false;
                    }
                    else
                    {
                        isFirst = true;
                        yield return new Tuple<T, T>(first, item);
                    }
                }
            }
        }
    }
