    static class Program
    {
        private static Random _random = new Random();
        private static AutoResetEvent[] _eventHandles = new[] {new AutoResetEvent(false), new AutoResetEvent(false)};
        static void Main()
        {
            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Method);
                threads[i].Start();
                var handleIndex = WaitHandle.WaitAny(_eventHandles);
                Console.WriteLine(handleIndex == 0 ? "Process1" : "Process2");
            }
        }
        static void Method()
        {
            if (_random.Next()%2 == 0)
                _eventHandles[0].Set();
            else
                _eventHandles[1].Set();
        }
    }
