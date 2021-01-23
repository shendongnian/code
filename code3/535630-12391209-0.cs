    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Diagnostics;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            //static int counter = 0;
            //static int counter2 = 0;
            //static int counter3 = 0;
            //static int counter4 = 0;
            class CounterHolder
            {
                private int[] fakeInts = new int[1024];
                public int Value = 0;
            }
            static CounterHolder counter1 = new CounterHolder();
            static CounterHolder counter2 = new CounterHolder();
            static CounterHolder counter3 = new CounterHolder();
            static CounterHolder counter4 = new CounterHolder(); 
            static void Main(string[] args)
            {
                Console.WriteLine("Without multithreading:");
                Console.WriteLine("Start: " + DateTime.Now.ToString());
                
                Stopwatch sw = new Stopwatch();
                sw.Start();
                countUp();
                countUp2();
                countUp3();
                countUp4();
                sw.Stop();
                Console.WriteLine("Time taken = " + sw.Elapsed.ToString());
                Console.WriteLine("\nWith multithreading:");
                Console.WriteLine("Start: " + DateTime.Now.ToString());
                sw.Reset();
                sw.Start();
                Task task1 = Task.Factory.StartNew(() => countUp());
                Task task2 = Task.Factory.StartNew(() => countUp2());
                Task task3 = Task.Factory.StartNew(() => countUp3());
                Task task4 = Task.Factory.StartNew(() => countUp4());
                var continuation = Task.Factory.ContinueWhenAll(new[] { task1, task2, task3, task4 }, tasks =>
                {
                    Console.WriteLine("Total Time taken = " + sw.Elapsed.ToString());
                });
                Console.Read();
            }
            static void countUp()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (double i = 0; i < 1000000000; i++)
                    counter1.Value++;
                sw.Stop();
                Console.WriteLine("Task countup took: " + sw.Elapsed.ToString());
            }
            static void countUp2()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (double i = 0; i < 1000000000; i++)
                    counter2.Value++;
                sw.Stop();
                Console.WriteLine("Task countUP2 took: " + sw.Elapsed.ToString());
            }
            static void countUp3()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (double i = 0; i < 1000000000; i++)
                    counter3.Value++;
                sw.Stop();
                Console.WriteLine("Task countUP2 took: " + sw.Elapsed.ToString());
            }
            static void countUp4()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (double i = 0; i < 1000000000; i++)
                    counter4.Value++;
                sw.Stop();
                Console.WriteLine("Task countUP2 took: " + sw.Elapsed.ToString());
            }
        } 
    }
