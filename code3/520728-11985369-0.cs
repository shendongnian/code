    using System;
    using System.Threading;
    
    class Program
    {
        static void Main()
        {
    	Thread thread1 = new Thread(new ThreadStart(A));
    	Thread thread2 = new Thread(new ThreadStart(B));
    	thread1.Start();
    	thread2.Start();
    	thread1.Join();
    	thread2.Join();
        }
    
        static void A()
        {
    	Thread.Sleep(100);
    	Console.WriteLine('A');
        }
    
        static void B()
        {
    	Thread.Sleep(1000);
    	Console.WriteLine('B');
        }
    }
