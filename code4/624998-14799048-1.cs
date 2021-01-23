    using System;
    using System.Threading;
    
    namespace StackOverflow
    {
        class Program
        {
            private static void Main(string[] args)
            {
                Console.Write("\a");
                Thread.Sleep(500);
                Console.Beep();
            }
        }
    }
