    class Program
    {
        static void Main(string[] args)
        {
            TestAsyncAwaitMethods();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
        public async static void TestAsyncAwaitMethods()
        {
            await LongRunningMethod();
        }
        public static async Task<int> LongRunningMethod()
        {
            Console.WriteLine("Starting Long Running method...");
            await Task.Delay(5000);
            Console.WriteLine("End Long Running method...");
            return 1;
        }
    }
