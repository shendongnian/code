                        var taskDefinition = taskService.NewTask();
                        taskDefinition.RegistrationInfo.Author = WindowsIdentity.GetCurrent().Name;
                        
                        taskDefinition.RegistrationInfo.Description = "Runs Application";
                        // TaskLogonType.S4U = run wether user is logged on or not 
                        taskDefinition.Principal.LogonType = TaskLogonType.S4U; 
                        var action = new ExecAction(path, arguments);
                        taskDefinition.Actions.Add(action);
                        taskService.RootFolder.RegisterTaskDefinition("NameOfApplication", taskDefinition);
