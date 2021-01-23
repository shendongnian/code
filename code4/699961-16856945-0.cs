    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    namespace Threaddd
    {
    internal class Program
    {
        private static int num = 0;
        private static EventWaitHandle e = new AutoResetEvent(false);
        private static object o = new object();
        private static void Main(string[] args)
        {
            new Thread(Consumer).Start();
            new Thread(Producer).Start();
        }
        private static void Producer()
        {
            while (true)
            {
                if (num == 0)
                {
                    num++;
                    Console.WriteLine("Produced " + num);
                    Thread.Sleep(1000);
                    e.Set();
                }
            }
        }
        private static void Consumer()
        {
            while (true)
            {
                if (num == 1)
                {
                    Console.WriteLine("Consumed " + num);
                    Thread.Sleep(1000);
                    num--;
                    e.WaitOne();
                }
            }
        }
    }
    }
