    abstract class Task
    {
        public readonly Object SyncObject = new Object();
    }
    List<Task> taskList = new List<Task>();
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
                        object syncObj = taskList[i].SyncObject;
                        if (found = Monitor.TryEnter(syncObj))
                        {
                            for (int x = 0; x < taskList.Count; x++)
                            {
                                if (Object.ReferenceEquals(
                                        syncObj, taskList[x].SyncObject))
                                {
                                    task = taskList[x];
                                    taskList.RemoveAt(x);
                                    break;
                                }
                            }
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
