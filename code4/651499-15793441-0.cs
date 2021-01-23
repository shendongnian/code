    [Dependency]
    public IMyService MyService{ get; set; }
    
    WorkflowApplication instance = new WorkflowApplication(myWorkflow, inParameters);
    instance.Extensions.Add(MyService);
    instance.Run();
