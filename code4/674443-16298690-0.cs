    using System;
    using System.Diagnostics;
    public static class ProcessStart
    {
        Process[] runningProcesses;
        var processesStartTimes = new Dictionary<int, Datetime>();
        var processesExitTimes = new Dictionary<int, Datetime>();
        
        static ProcessStart()
        {
            // This will get current running processes
            runningProcesses = Process.GetProcesses();
            foreach (var p in processes)
            {
                p.Exited += new EventHandler(ProcessExited);
                processesStartTimes.Add(p.Id, p.StartTime);
            }
        }
        private void ProcessExited(object sender, System.EventArgs e)
        {
            var p = (Process)sender;
            processesExitTimes.Add(p.Id, p.ExitTime);
        }
    }
