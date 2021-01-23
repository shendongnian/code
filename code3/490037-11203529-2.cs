    using System;
    using System.Diagnostics;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                int count = 1000000000;
                Stopwatch sw = Stopwatch.StartNew();
                for (int way = 1; way <= 3; ++way)
                    test1(count, way);
                var elapsed1 = sw.Elapsed;
                Console.WriteLine("test1() took " + elapsed1);
                sw.Restart();
                for (int way = 1; way <= 3; ++way)
                    test2(count, way);
                var elapsed2 = sw.Elapsed;
                Console.WriteLine("test2() took " + elapsed2);
                Console.WriteLine("test2() was {0:f1} times as fast.", + ((double)elapsed1.Ticks)/elapsed2.Ticks);
            }
            static void test1(int count, int way)
            {
                for (int i = 0; i < count; ++i)
                {
                    switch (way)
                    {
                        case 1: doWork1(); break;
                        case 2: doWork2(); break;
                        case 3: doWork3(); break;
                    }
                }
            }
            static void test2(int count, int way)
            {
                switch (way)
                {
                    case 1:
                        for (int i = 0; i < count; ++i)
                            doWork1();
                        break;
                    case 2:
                        for (int i = 0; i < count; ++i)
                            doWork2();
                        break;
                    case 3:
                        for (int i = 0; i < count; ++i)
                            doWork3();
                        break;
                }
            }
            static void doWork1()
            {
            }
            static void doWork2()
            {
            }
            static void doWork3()
            {
            }
        }
    }
