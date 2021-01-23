    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
        public static async Task MainAsync()
        {
            Task task1 = Task1();
            Task task2 = Task2();
            await Task.WhenAll(task1, task2);
            Debug.WriteLine("Finished main method");
        }
        public static async Task Task1()
        {
            await Task.Delay(5000);
            Debug.WriteLine("Finished Task1");
        }
        public static async Task Task2()
        {
            await Task.Delay(10000);
            Debug.WriteLine("Finished Task2");
        }
    }
