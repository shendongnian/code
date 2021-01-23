     if (Process.GetProcesses().Count(p => p.ProcessName == "exe name") > 1)
        {
            foreach (var process in 
     Process.GetProcessesByName("exe name"))
            {
                process.Kill();
            }
        }
