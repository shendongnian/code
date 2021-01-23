    static class Program
    {
        private static Random _random = new Random();
        private static AutoResetEvent[] _eventHandles = new[] {new AutoResetEvent(false), new AutoResetEvent(false)};
        static void Main()
        {
            ThreadPool.RegisterWaitForSingleObject(_eventHandles[0], Process1, null, Timeout.Infinite, false);
            ThreadPool.RegisterWaitForSingleObject(_eventHandles[1], Process2, null, Timeout.Infinite, false);
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
        static void Process1(object state, bool timedOut)
        {
            Console.WriteLine("Process1");
        }
        static void Process2(object state, bool timedOut)
        {
            Console.WriteLine("Process2");
        }
    }
