    class Program
    {
        static void Main(string[] args)
        {
            OnThread(MethodA);
            OnThread(MethodB, "My argument");
            Console.ReadKey();
        }
        private static void OnThread(Action action)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                action.Invoke();
            }, null);
        }
        private static void OnThread<T>(Action<T> action, T arg1)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                action.Invoke(arg1);
            }, null);
        }
        private static void MethodA()
        {
            Output();
        }
        private static void MethodB(string argument)
        {
            Output();
        }
        private static void Output([CallerMemberName] string methodName = null)
        {
            Console.WriteLine(methodName);
        }
    }
