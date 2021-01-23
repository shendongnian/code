    public void DoWork()
    {
        // Queue a task.
        System.Threading.ThreadPool.QueueUserWorkItem(
            new System.Threading.WaitCallback(SomeLongTask));
        // Queue another task.
        System.Threading.ThreadPool.QueueUserWorkItem(
            new System.Threading.WaitCallback(AnotherLongTask));
    }
    
    private void SomeLongTask(Object state)
    {
        // Insert code to perform a long task.
    }
    
    private void AnotherLongTask(Object state)
    {
        // Insert code to perform a long task.
    }
