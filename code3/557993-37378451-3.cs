       WorkflowApplication wfApp = new WorkflowApplication(wf);
       wfApp.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs e)
       {
             return PersistableIdleAction.Persist;
       };
       // Start the workflow.
       wfApp.Run();
