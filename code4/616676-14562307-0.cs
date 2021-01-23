    using System;
    using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            // Easy way to start a thread with strongly-typed multiple parameters:
            new Thread(() => MyThreadFunc("Test", 42, DateTime.Now)).Start();
            Console.WriteLine("Started thread.");
            Thread.Sleep(2000);
        }
        static void MyThreadFunc(string param1, int param2, DateTime param3)
        {
            Thread.Sleep(1000);
            Console.WriteLine("param1 = {0}, param2 = {1}, param3 = {2}", param1, param2, param3);
        }
    }
