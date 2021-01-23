    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            private void run()
            {
                test(1000);
                test(10000);
                test(100000);
            }
            private void test(int n)
            {
                var items = Enumerable.Range(0, n);
                new Action(() => items.Distinct().Count())
                    .TimeThis("Distinct() with n == " + n + ": ", 10000);
            }
            static void Main()
            {
                new Program().run();
            }
        }
        static class DemoUtil
        {
            public static void TimeThis(this Action action, string title, int count = 1)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    action();
                Console.WriteLine("Calling {0} {1} times took {2}",  title, count, sw.Elapsed);
            }
        }
    }
