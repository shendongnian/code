    using TaskPair = KeyValuePair<Func, object[]>;
    ...
    private Queue<TaskPair> taskQueue;
    ...
    // generate the queue of tasks
    this.taskQueue = new Queue<TaskPair>(this.DataGridViewUrg.Rows);
    foreach (DataGridViewRow row in this.DataGridViewUrg.Rows)
    {
        var task = new TaskPair(Run(DrgDataRowInfo(row.Index)), /* params */);
        this.taskQueue.Enqueue(task);
    }
    // initiate queue processing
    ProcessNext();
    ....
    private void ProcessNext()
    {
        try
        {
            var item = this.taskQueue.Dequeue();
            TaskSpin(item.Key, item.Value);
        }
        catch(InvalidOperationException)
        {
            // queue is empty
        }   
    }
    ....
    // run the first task, handle the rest in the continuation
    public TaskSpin(Func asyncMethod, object[] methodParameters)           
    {            
        ...           
        asyncTask = Task.Factory.StartNew<bool>(() =>            
            asyncMethod(uiScheduler, methodParameters));           
           
        asyncTask.ContinueWith(task =>           
        {           
            // Finish the processing update UI etc.
            ProcessNext();           
        }  
        ...                 
    }
