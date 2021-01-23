    Tasks[] tasks = new Task[count];
    
    for (int index = 0; index < count; index++)
    {
    
        if (index < _noOfThreads)
             tasks[index] = Task.Factory.StartNew(somedelegate);
        else
             tasks[index] = tasks[index % _noOfThreads].ContinueWith(task => { foo.bar(); }, 
                                TaskContinuationOptions.AttachedToParent);
    }
    Task.WaitAll(tasks);
