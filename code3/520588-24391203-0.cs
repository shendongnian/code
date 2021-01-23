    using (TaskService ts = new TaskService())
    {
        var newTask = ts.NewTask();
        newTask.Principal.UserId = "SYSTEM";
        newTask.Triggers.Add(new TimeTrigger(DateTime.Now));
        newTask.Actions.Add(new ExecAction("notepad"));
        ts.RootFolder.RegisterTaskDefinition("NewTask", newTask);
    }
