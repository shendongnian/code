    class Program
    {
        static object _locker1 = new object();
        static object _locker2 = new object();
        static void Main(string[] args)
        {
            Thread first = new Thread(FirstThread);
            first.Start();
            Thread second = new Thread(SecondThread);
            second.Start();
            
        }
        static void FirstThread(object obj)
        {
            // Lock resource 1
            lock(_locker1)
            {
                Console.WriteLine("Thread 1: locked resource 1");
                try
                {
                    Thread.Sleep(50);
                }
                catch (ThreadInterruptedException e) {}
                lock(_locker2)
                {
                    Console.WriteLine("Thread 1: locked resource 2");
                }
            }
        }
        static void SecondThread(object obj)
        {
            // Lock resource 1
            lock (_locker2)
            {
                Console.WriteLine("Thread 2: locked resource 2");
                try
                {
                    Thread.Sleep(50);
                }
                catch (ThreadInterruptedException e) { }
                lock (_locker1)
                {
                    Console.WriteLine("Thread 2: locked resource 1");
                }
            }
        }
    }
