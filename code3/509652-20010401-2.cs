    static class Program
    {
        static void Main()
        {
            Run(() => 5);  // compiles, goes to generic overload
            Run(M);        // won't compile!
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
