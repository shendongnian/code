    Process[] processRunning = System.Diagnostics.Process.GetProcesses();
    foreach (Process pr in processRunning)
    {
        if (pr.ProcessName == "excel")
        {
           pr.Kill();
        }
    }
