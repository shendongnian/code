    using System;
    using System.Threading;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    test();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Handled Exception: " + ex.Message);
                }
            }
            static void test()
            {
                Thread.CurrentThread.Abort();
            }
        }
    }
