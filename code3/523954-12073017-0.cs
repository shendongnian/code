    // create Test Case Sources
    public object[] insertScenarios = 
            {
                new object[] { typeof(RaiseScenario), this.workflowRuntime, Description, true, true, string.Empty },
                new object[] { typeof(RaiseScenario), this.workflowRuntime, Description, true, false, "New Reason" }
            };
    /// <summary>
    /// The init.
    /// </summary>
    [SetUp]
    public void Init()
    {
        // set up workflow scheduler and runtime
        this.workflowRuntime = new WorkflowRuntime();
        this.scheduler = new ManualWorkflowSchedulerService(true); // run synchronously
        this.workflowRuntime.AddService(this.scheduler);
        this.workflowRuntime.StartRuntime();
    }
