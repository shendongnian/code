    var taskList = new List<Task>{task1,task2};
    Task.Factory.ContinueWhenAll(taskList.ToArray(), 
        (tasks)=>
        {
            label1.Text = "Results are: ";
            foreach(var task in tasks)
            {
                //process each task
                label1.Text += task.Result + "|";
            } 
        }, 
        new CancellationTokenSource().Token, TaskContinuationOptions.None,
        //This is to auto invoke back into the original thread
        TaskScheduler.FromCurrentSynchronizationContext()); 
