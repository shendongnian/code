    private object syncRoot =new object();
    private Task latestTask;
    
    public void EnqueueAction(System.Action action)
    {
        lock (syncRoot)
        {
            if (latestTask == null)
                latestTask = Task.Factory.StartNew(action);
            else
                latestTask = latestTask.ContinueWith(tsk => action());
        }
    }
