    public static class ProcessStart
    {
        Process[] runningProcesses;
        var processesStartTimes = new Dictionary<int, Datetime>();
        var processesExitTimes = new Dictionary<int, Datetime>();
        var updateTimer = new Timer(1000);
        
        static ProcessStart()
        {
            // This will get current running processes
            runningProcesses = Process.GetProcesses();
            foreach (var p in processes)
            {
                p.Exited += new EventHandler(ProcessExited);
                processesStartTimes.Add(p.Id, p.StartTime);
            }
            updateTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }
        private void ProcessExited(object sender, System.EventArgs e)
        {
            var p = (Process)sender;
            processesExitTimes.Add(p.Id, p.ExitTime);
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            runningProcesses = Process.GetProcesses();
            foreach (var p in processes)
            {
                // This will only add the processes that are not added yet
                if (!processesStartTimes.Keys.Contains(p.Id))
                {
                    p.Exited += new EventHandler(ProcessExited);
                    processesStartTimes.Add(p.Id, p.StartTime);
                }
            }
        }
    }
