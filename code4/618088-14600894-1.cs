    private static void Main(string[] args)
    {
        bool hasPendingWork = true;
        do
        {
            var tasks = InitiateTasks();
    
            Task.WaitAll(tasks);
    
            Console.WriteLine("Finished batch...");
        } while (hasPendingWork);
    }
    
    private static Task[] InitiateTasks()
    {
        var tasks = new Task[4];
    
        for (int i = 0; i < tasks.Length; i++)
        {
            int wait = 1000*i;
    
            tasks[i] = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(wait);
                Console.WriteLine("Finished waiting: {0}", wait);
            });
        }
    
        return tasks;
    }
