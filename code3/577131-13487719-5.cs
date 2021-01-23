    public void RunAllSelectedTaskOptions(List<SelectedTask> selectedTaskOptions)
    {
        List<Task> createdTasks = new List<Task>();
    
        foreach(var taskOption in selectedTaskOptions)
        {
            createdTasks.Add(Task.Factory.CreateNew(() => doOne(taskOption)));
        }
        
        Task.WaitAll(createdTasks);
    }
