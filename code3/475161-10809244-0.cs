    private void AddTasksToApp(Application appNotAssociatedWithContext, Application appFromContext)
    {
        foreach (TaskBase taskModified in appNotAssociatedWithContext.Tasks)
        {
            if (taskModified.IdForEf == 0)
            {
                appFromContext.Tasks.Add(taskModified);
            }
            else
            {
                TaskBase taskBase = appFromContext.Tasks.Single(x => x.IdForEf == taskModified.IdForEf);  // Get original task
                this.Database.Entry(taskBase).CurrentValues.SetValues(taskModified);  // Update with new
            }
        }
        // Delete tasks that no longer exist within the app.
        List<TaskBase> tasksToDelete = new List<TaskBase>();
        foreach (TaskBase originalTask in appFromContext.Tasks)
        {
            TaskBase task = appNotAssociatedWithContext.Tasks.Where(x => x.IdForEf == originalTask.IdForEf).FirstOrDefault();
            if (task == null)
            {                    
                tasksToDelete.Add(originalTask);
            }
        }
        foreach (TaskBase taskToDelete in tasksToDelete)
        {                
            appFromContext.Tasks.Remove(taskToDelete);
            this.Database.TaskBases.Remove(taskToDelete);
        }
    }
