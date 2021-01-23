    public static void WaitAll(this IEnumerable<Task> tasks) 
    {
        Task.WaitAll(tasks.ToArray());
    }      
    TaskList.WaitAll();
