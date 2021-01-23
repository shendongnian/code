    private static object _syncObject = new object();
    
    private void TaskCompleted(object sender, TaskCompletedEvent e)
    {
        Model.Task scheduledTask = entitySet.Tasks.First(x => x.TaskName == e.ClassName);
        TaskLog logMsg = new TaskLog()
        {
            //stuff here
        };
    
        scheduledTask.TaskLogs.Add(logMsg);
        lock(_syncObject){
            entitySet.SaveChanges();
        }
    }
