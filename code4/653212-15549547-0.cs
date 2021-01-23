    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace Demo
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                List<Test> list = new List<Test>
                {
                    new Test(1, 1),
                    new Test(2, 1),
                    new Test(3, 2),
                    new Test(4, 2)
                };
                var uniques = list.DistinctBy(item => item.LinkId);
                foreach (var item in uniques)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public class Test
        {
            public Test(int linkSysId, int linkId)
            {
                LinkSysId = linkSysId;
                LinkId = linkId;
            }
            public override string ToString()
            {
                return string.Format("LinkSysId = {0}, LinkId = {1}", LinkSysId, LinkId);
            }
            public int LinkSysId;
            public int LinkId;
        }
        static class EnumerableExt
        {
            public static IEnumerable<TSource> DistinctBy<TSource, TKey>
                (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            {
                return source.DistinctBy(keySelector, null);
            }
            public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
                Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                if (source == null) throw new ArgumentNullException("source");
                if (keySelector == null) throw new ArgumentNullException("keySelector");
                return DistinctByImpl(source, keySelector, comparer);
            }
            private static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(IEnumerable<TSource> source,
                Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var knownKeys = new HashSet<TKey>(comparer);
                return source.Where(element => knownKeys.Add(keySelector(element)));
            }
        }
    }
