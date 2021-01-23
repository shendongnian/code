    using System;
    using Microsoft.Win32.TaskScheduler;
    class Program
    {
       static void Main(string[] args)
       {
          TaskService ts = new TaskService();          
          TaskDefinition td = ts.NewTask();
          td.Principal.RunLevel = TaskRunLevel.Highest;
          //td.Triggers.AddNew(TaskTriggerType.Logon);          
          td.Triggers.AddNew(TaskTriggerType.Once);    // 
          string program_path = @"c:\wamp\wampmanager.exe"; // you can have it dynamic
    //even of user choice giving an interface in win-form or wpf application
    
          td.Actions.Add(new ExecAction(program_path, null));
          ts.RootFolder.RegisterTaskDefinition("anyNamefortask", td);          
       }
    }
