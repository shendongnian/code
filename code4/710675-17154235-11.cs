    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            void run()
            {
                var lst1 = Enumerable.Range(0, 10000);
                var lst2 = Enumerable.Range(10000, 10000);
                int count = 10;
                DemoUtil.Time(() => lst1.Intersect(lst2).Any(), "intersect", count);
                DemoUtil.Time(() => lst1.Any(lst2.Contains),     "any",      count);
            }
            static void Main()
            {
                new Program().run();
            }
        }
        static class DemoUtil
        {
            public static void Print(this object self)
            {
                Console.WriteLine(self);
            }
            public static void Print(this string self)
            {
                Console.WriteLine(self);
            }
            public static void Print<T>(this IEnumerable<T> self)
            {
                foreach (var item in self)
                    Console.WriteLine(item);
            }
            public static void Time(Action action, string title, int count)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    action();
                (title + " took " + sw.Elapsed).Print();
            }
        }
    }
