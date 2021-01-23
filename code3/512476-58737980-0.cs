    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using TaskScheduler;
    private void CreateWindowsTask()
    {
        TaskScheduler.TaskScheduler ts = new TaskScheduler.TaskScheduler();
        ts.Connect(null, null, null, null); //connect to local machine as current user
        ITaskDefinition task = ts.NewTask(0);
        task.RegistrationInfo.Author = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        task.RegistrationInfo.Description = "Put your desription here";
        ITrigger trigger = (ITrigger)task.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_DAILY);
        trigger.Id = "MyTimeTrigger";
        string StartTime = "T" + DateTime.Now.ToString("HH:MM:00");
        trigger.StartBoundary = DateTime.Now.ToString("yyyy-MM-dd") + StartTime;
        trigger.EndBoundary = DateTime.Now.Date.AddYears(2).ToString("yyyy-MM-dd") + "T12:00:00";
        trigger.Repetition.Interval = "PT5M";   //5 minutes
        trigger.Repetition.Duration = "P1D";    //repeat for 1 day
        trigger.Repetition.StopAtDurationEnd = true;
        IExecAction action = (IExecAction)task.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
        action.Id = "MyAction";
        action.Path = "C:\\Windows\\System32\\notepad.exe";
        ITaskFolder root = ts.GetFolder("\\");
        IRegisteredTask regTask = root.RegisterTaskDefinition(
            "Task Scheduler Demo",
            task,
            (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE,
            null, null, //user, passwrod
            _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN,
            ""          //sddl
            );
        IRunningTask runTask = regTask.Run(null);
    }
