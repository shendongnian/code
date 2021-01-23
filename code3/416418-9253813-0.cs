      PeriodicTask task = ScheduledActionService.Find("MyTaskName") as PeriodicTask;
      if ((task != null) && (task.IsEnabled == true)) {
        ScheduledActionService.Remove("MyTaskName");
      }
      task = new PeriodicTask("MyTaskName") {
        Description = "My Periodic Task",
      };
      ScheduledActionService.Add(task);
    #if DEBUG
      if (System.Diagnostics.Debugger.IsAttached == true) {
        ScheduledActionService.LaunchForTest("MyTaskName", TimeSpan.FromSeconds(10));
      }
    #endif
