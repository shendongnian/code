    enum Process
    {
        Process1,
        Process2
    }
    static class Program
    {
        private static Random _random = new Random();
        private static AutoResetEvent _eventHandle = new AutoResetEvent(false);
        private static volatile Process _selectedProcess = Process.Process1;
        static void Main()
        {
            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Method);
                threads[i].Start();
                _eventHandle.WaitOne();
                Console.WriteLine(_selectedProcess == Process.Process1 ? "Process1" : "Process2");
            }
        }
        static void Method()
        {
            _selectedProcess = _random.Next()%2 == 0 ? Process.Process1 : Process.Process2;
            _eventHandle.Set();
        }
    }
