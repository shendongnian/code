    private static SemaphoreSlim TaskController = new SemaphoreSlim(4);
    
    private static void Main(string[] args)
    {
        var random = new Random(570);
    
        while (true)
        {
            // Blocks thread without wasting CPU
            // if the number of resources (4) is exhausted
            TaskController.Wait();
    
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Started");
                Thread.Sleep(random.Next(1000, 3000));
                Console.WriteLine("Completed");
                // Releases a resource meaning TaskController.Wait will unblock
                TaskController.Release();
            });
        }
    }
