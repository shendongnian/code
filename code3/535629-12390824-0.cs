    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static int counter = 0;
            static int counter2 = 0;
            static int counter3 = 0;
            static int counter4 = 0;
    
            static void Main(string[] args)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
    
                countUp();
                countUp2();
                countUp3();
                countUp4();
    
                stopwatch.Stop();
                Console.WriteLine("Time elapsed without multithreading:: {0}",
            stopwatch.Elapsed);
    
                stopwatch.Reset();
                stopwatch.Start();
    
                Thread thread1 = new Thread(new ThreadStart(countUp));
                thread1.Start();
                Thread thread2 = new Thread(new ThreadStart(countUp2));
                thread2.Start();
                Thread thread3 = new Thread(new ThreadStart(countUp3));
                thread3.Start();
                Thread thread4 = new Thread(new ThreadStart(countUp4));
                thread4.Start();
    
                thread1.Join();
                thread2.Join();
                thread3.Join();
                thread4.Join();
    
                stopwatch.Stop();
                Console.WriteLine("Time elapsed with multithreading:: {0}",
            stopwatch.Elapsed);
    
                Console.Read();
            }
    
            static void countUp()
            {
                for (double i = 0; i < 1000000000; i++)
                {
                    counter++;
                }
            }
    
            static void countUp2()
            {
                for (double i = 0; i < 1000000000; i++)
                {
                    counter2++;
                }
            }
    
            static void countUp3()
            {
                for (double i = 0; i < 1000000000; i++)
                {
                    counter3++;
                }
            }
    
            static void countUp4()
            {
                for (double i = 0; i < 1000000000; i++)
                {
                    counter4++;
                }
            }
        }
    }
