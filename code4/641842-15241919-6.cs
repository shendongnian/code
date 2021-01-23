    static class Program
    {
        private static Random _random = new Random();
        private static AutoResetEvent[] _eventHandles = new[] {new AutoResetEvent(false), new AutoResetEvent(false)};
        static void Main()
        {
            Thread[] processThreads = new Thread[2];
            processThreads[0] = new Thread(Process1);
            processThreads[0].Start();
            processThreads[1] = new Thread(Process2);
            processThreads[1].Start();
            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Method);
                threads[i].Start();
            }
        }
        static void Method()
        {
            if (_random.Next()%2 == 0)
                _eventHandles[0].Set();
            else
                _eventHandles[1].Set();
        }
        static void Process1()
        {
            while (true)
            {
                _eventHandles[0].WaitOne();
                Console.WriteLine("Process1");
            }
        }
        static void Process2()
        {
            while (true)
            {
                _eventHandles[1].WaitOne();
                Console.WriteLine("Process2");
            }
        }
    }
