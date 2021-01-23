    using System;
    using System.Threading;
    
    class Test
    {
        public static void Main(string[] args)
        {
            ThreadStart action = Count;
            Thread thread = new Thread(action);
            thread.Start();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main thread...");
                Thread.Sleep(1000);
            }
        }
            
        static void Count()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Secondary thread...");
                Thread.Sleep(300);
            }        
        }
    }
