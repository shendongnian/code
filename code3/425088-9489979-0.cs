    var task1 = Task.Factory.StartNew(()=>{//Do Work});
    var task2 = Task.Factory.StartNew(()=>{//Do Work on other numbers});
    task1.ContinueWith((previousTask)=>{//Return back to the main thread}
        , new CancellationTokenSource().Token, TaskContinuationOptions.None,
        //This is to auto invoke back into the original thread
        TaskScheduler.FromCurrentSynchronizationContext()); 
    task2.ContinueWith((previousTask)=>{//Return back to the main thread}
        , new CancellationTokenSource().Token, TaskContinuationOptions.None,
        //This is to auto invoke back into the original thread
        TaskScheduler.FromCurrentSynchronizationContext()); 
