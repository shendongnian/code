    var task1 = Task.Factory.StartNew<int>(()=>
        {
            //Do Work
            return 1;//return the value that was computed
        });
    var task2 = Task.Factory.StartNew<int>(()=>
        {
            //Do Work
            return 2;//return the value that was computed
        });
    task1.ContinueWith((previousTask)=>
        {
            //Return back to the main thread
            label1.Text += "The value of task1 is going to be 1-->" 
                           + previousTask.Result;
        }
        , new CancellationTokenSource().Token, TaskContinuationOptions.None,
        //This is to auto invoke back into the original thread
        TaskScheduler.FromCurrentSynchronizationContext()); 
    task2.ContinueWith((previousTask)=>
        {
            //Return back to the main thread
            label1.Text += "The value of task2 is going to be 2-->" 
                           + previousTask.Result;
        }
        , new CancellationTokenSource().Token, TaskContinuationOptions.None,
        //This is to auto invoke back into the original thread
        TaskScheduler.FromCurrentSynchronizationContext()); 
