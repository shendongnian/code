    abstract class Task
    {
        public readonly Object SyncObject = new Object();
    }
    private static List<Task> taskList = new List<Task>();
    void TakeItemThreadedMethod()
    {
        Task task = null;
        bool found = false;
        try
        {
            // loop until found an task whose SyncObject is free
            while (!found)
            {
                lock (taskList)
                {
                    for (int i = 0; i < taskList.Count; i++)
                    {
                        task = taskList[i];
                        if (found = Monitor.TryEnter(task.SyncObject))
                        {
                            taskList.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            // process the task...
            DoWork(task);
        }
        finally
        {
            if (found) Monitor.Exit(task.SyncObject);
        }
    }
    void QueueTask(Task task)
    {
        lock (taskList)
        {
            taskList.Add(task);
        }
    }
