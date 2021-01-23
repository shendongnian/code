    var tasks[] = new Task[n];
    for (int i = 0; i < n; ++i)
    {
       tasks[i] = new Task(() => Console.WriteLine(123));
       tasks[i].Start();
    }
     
    Tasks.WaitAll(tasks);
    Console.WriteLine("DONE");
