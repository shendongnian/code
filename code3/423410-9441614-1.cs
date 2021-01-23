    var tasks = new Task[10];
    for (int i=0;i<10;i++)
    {
        tasks[i] = Task.Factory.StartNew( Go );
    }
    Task.WaitAll(tasks);
    Console.WriteLine("All done");
    
    void Go()
    {
       Console.WriteLine("Hello");
    }
