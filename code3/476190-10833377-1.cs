    using System;
    using Microsoft.Win32.TaskScheduler;
    
    class Program
    {
       static void Main(string[] args)
       {
          // Get the service on the local machine
          using (TaskService ts = new TaskService())
          {
             // Create a new task definition and assign properties
             TaskDefinition td = ts.NewTask();
             td.RegistrationInfo.Description = "Does something";
    
             // Create a trigger that will fire after the system boot
             td.Triggers.Add(new BootTrigger() );
    
             // Create an action that will launch Notepad whenever the trigger fires
             td.Actions.Add(new ExecAction("notepad.exe", "c:\\test.log", null));
    
             // Register the task in the root folder
             ts.RootFolder.RegisterTaskDefinition(@"Test", td);
    
             // Remove the task we just created
             ts.RootFolder.DeleteTask("Test");
          }
       }
    }
