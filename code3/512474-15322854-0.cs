        // Get the service on the local machine
        using (var ts = new TaskService())
        {
          // Create a new task definition and assign properties
          TaskDefinition td = ts.NewTask();
          td.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew;          
          td.RegistrationInfo.Description = "FTP, Photo and Cleanup tasks";
          // Create a trigger that will execute very 2 minutes. 
          var trigger = new TimeTrigger();
          trigger.Repetition.Interval = TimeSpan.FromMinutes(2);                    
          td.Triggers.Add(trigger);         
          
          // Create an action that will launch my jobs whenever the trigger fires
          td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetExecutingAssembly().Location, null, Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
          // Register the task in the root folder
          ts.RootFolder.RegisterTaskDefinition(@"My Task Name", td);
        }
