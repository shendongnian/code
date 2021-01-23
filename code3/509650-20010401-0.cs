    static class Program
    {
        static void Main()
        {
            Run(() => 5);
            Run(M);
        }
        static void Run(Action a)
        {
        }
        static void Run<T>(Func<T> f)
        {
        }
        static int M()
        {
            return 5;
        }
    }
