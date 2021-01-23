    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                // Do any async anything you need here without worry
            }).GetAwaiter().GetResult();
        }
    }
