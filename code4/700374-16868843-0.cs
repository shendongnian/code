    Queue<Queue<object[]>> MasterQueue = new Queue<Queue<object[]>>();
    
    List<Task> tasks = new List<Task>();
    
    while (MasterQueue.Count > 0)
    {
     Queue<object[]> Queue = MasterQueue.Dequeue();
    
     //Send Queue to an Async Worker for processing...
     tasks.Add(Process(queue));
     //Lets say 5 in total that finish randomly so 3, 2, 5, 4, 1
    }
    
    Task.WaitAll(tasks.ToArray());
    // tasks are already in order
