    var trigger = new SystemTrigger(SystemTriggerType.InternetAvailable, false);
    var condition = new SystemCondition(SystemConditionType.InternetAvailable);
    
    var builder = new BackgroundTaskBuilder();
    builder.Name = "Send pending e-mails task";
    builder.TaskEntryPoint = "Tasks.SendPendingEmailTask";
    builder.SetTrigger(trigger);
    builder.AddCondition(condition);
    var task = builder.Register();
