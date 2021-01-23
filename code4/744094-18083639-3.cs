    // Used while a work item is processing. If you have something that you want to wait on this process. Or you could use event handlers or something.
    private DispatcherFrame CompleteFrame;
    // Controls blocking of the thread.
    private DispatcherFrame TaskFrame;
    // Set to true to stop the task manager.
    private bool Close;
    // A collection of tasks you want to queue up on this specific thread. 
    private List<jTask> TaskCollection;
    public void QueueTask(jTask newTask)
    {
        //Task Queued.
        lock (TaskCollection) { TaskCollection.Add(newTask); }
        if (TaskFrame != null) { TaskFrame.Continue = false; }
    }
    // Call this method when you want to start the task manager and let it wait for a task.
    private void FireTaskManager()
    {
        do
        {
            if (TaskCollection != null)
            {
                if (TaskCollection.Count > 0 && TaskCollection[0] != null) 
                { 
                    ProcessWorkItem(TaskCollection[0]);
                    lock (TaskCollection) { TaskCollection.RemoveAt(0); }
                }
                else { WaitForTask(); }
            }
        }
        while (!Close);
    }
    // Call if you are waiting for something to complete.
    private void WaitForTask()
    {
        if (CompleteFrame != null) { CompleteFrame.Continue = false; }
        // Waiting For Task.
        TaskFrame = new DispatcherFrame(true);
        Dispatcher.PushFrame(TaskFrame);
        TaskFrame = null;
    }
    /// <summary>
    /// Pumping block will release when all queued tasks are complete. 
    /// </summary>
    private void WaitForComplete()
    {
        if (TaskCollection.Count > 0)
        {
            CompleteFrame = new DispatcherFrame(true);
            Dispatcher.PushFrame(CompleteFrame);
            CompleteFrame = null;
        }
    }
    private void ProcessWorkItem(jTask taskItem)
    {
        if (taskItem != null) { object obj = taskItem.Go(); }
    }
