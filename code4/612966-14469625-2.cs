    Process[] processlist = Process.GetProcesses();
    foreach(Process process in processlist)
    {
       Console.WriteLine("Process: {0} ID: {1}", process.ProcessName, process.Id);
    }
