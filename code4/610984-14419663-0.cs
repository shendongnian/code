    var taskService = new TaskService();
    var task = taskService.NewTask();
    task.Triggers.Add(new WeeklyTrigger(DaysOfTheWeek.Friday, 1));
    task.Actions.Add(new ExecAction("YourProgram.exe", null, null));
    task.RootFolder.RegisterTaskDefinition("YourTaskName", task);
