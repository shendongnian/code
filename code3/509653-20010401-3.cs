    static class Program
    {
        static void Main()
        {
            Run(() => int.Parse("5"));  // compiles!
        }
        static void Run(Action a)
        {
        }
        static void Run<T>(Func<T> f)
        {
        }
    }
