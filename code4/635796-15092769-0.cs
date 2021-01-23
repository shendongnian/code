    using System;
    using System.Collections.Generic;
    using System.Drawing;
    namespace Demo
    {
        public static class EnumerableExt
        {
            public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
            {
                using (IEnumerator<TSource> sourceIterator = source.GetEnumerator())
                {
                    if (!sourceIterator.MoveNext())
                    {
                        throw new InvalidOperationException("Sequence was empty");
                    }
                    TSource min = sourceIterator.Current;
                    TKey minKey = selector(min);
                    while (sourceIterator.MoveNext())
                    {
                        TSource candidate = sourceIterator.Current;
                        TKey candidateProjected = selector(candidate);
                        if (comparer.Compare(candidateProjected, minKey) < 0)
                        {
                            min    = candidate;
                            minKey = candidateProjected;
                        }
                    }
                    return min;
                }
            }
            public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
            {
                return source.MinBy(selector, Comparer<TKey>.Default);
            }
        }
        public static class Program
        {
            static void Main(string[] args)
            {
                List<Point> points = new List<Point>
                {
                    new Point(7, 43),
                    new Point(7, 42),
                    new Point(6, 42),
                    new Point(5, 42),
                    new Point(6, 43),
                    new Point(5, 43)
                };
                var result = points.MinBy( p => p.X*p.X + p.Y*p.Y );
                Console.WriteLine(result);
            }
        }
    }
