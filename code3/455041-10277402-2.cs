     while (mRunning)
     {
        //mNoTaskEvent.WaitOne();
        if (!mRunning) break;
        Task nextTask;
        lock (mTasks)
        {
            while (mTasks.Count < 1)
            {
               Monitor.Wait(mTasks);
               if (!mRunning) break;                
            }
         
            ...     
        }
    public void AddTask(Task task)
    {
      lock (mTasks)
      {
         mTasks.Add(task);
         //mNoTaskEvent.Set();
         Monitor.Pulse(mTasks);
      }
    }
