    private DispatcherFrame CompleteFrame;
    private DispatcherFrame TaskFrame;
    private bool Close;
    private List<jTask> TaskCollection;
    public void QueueTask(jTask newTask)
    {
        //Task Queued.
        lock (TaskCollection) { TaskCollection.Add(newTask); }
        if (TaskFrame != null) { TaskFrame.Continue = false; }
    }
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
