    public static void StartTasks()
    {
        Task[] tasks = new Task[10];
        for (int i = 0; i < 10; i++) {
            int j = 1;
            tasks[i] = new Task(() => Console.WriteLine(j));
        }
    
        foreach (Task task in tasks)
        {
            task.Start();                       
        }       
    }
