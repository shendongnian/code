    class Program
    {
        static void Main(string[] args)
        {
            TestAsync async = new TestAsync();
            async.Go().Wait();
        }
    }
