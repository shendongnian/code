    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Threading;
    namespace Demo
    {
        class Program
        {
            void run()
            {
                for (int i = 1; i < 10; ++i)
                    test(i);
                for (int i = 10; i < 100; i += 5)
                    test(i);
                for (int i = 100; i < 200; i += 10)
                    test(i);
                for (int i = 200; i < 500; i += 20)
                    test(i);
            }
            void test(int millisecs)
            {
                var sw = Stopwatch.StartNew();
                accurateWait(millisecs);
                Console.WriteLine("Requested wait = " + millisecs + ", actual wait = " + sw.ElapsedMilliseconds);
            }
            void accurateWait(int millisecs)
            {
                var sw = Stopwatch.StartNew();
                if (millisecs >= 100)
                    Thread.Sleep(millisecs - 50);
                while (sw.ElapsedMilliseconds < millisecs)
                    ;
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
