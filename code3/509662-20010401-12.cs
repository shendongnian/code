    class Program
    {
        static void Main()
        {
            Run(M);        // won't compile!
        }
        static void Run(Func<int> f)
        {
        }
        static void Run(Func<FileStream> f)
        {
        }
        static int M()
        {
            return 5;
        }
    }
