    using System;
    using Microsoft.Win32.TaskScheduler;
    class Program
    {
       static void Main(string[] args)
       {
          TaskService ts = new TaskService();          
          TaskDefinition td = ts.NewTask();
          td.Principal.RunLevel = TaskRunLevel.Highest;
          //td.Triggers.AddNew(TaskTriggerType.YourDesiredSchedule);
          td.Triggers.AddNew(TaskTriggerType.Logon);    
          //td.Actions.Add(new ExecAction("Path Of your Application File", null));
          td.Actions.Add(new ExecAction(@"c:\wamp\wampmanager.exe", null));
          ts.RootFolder.RegisterTaskDefinition("anyNamefortask", td);          
       }
    }
