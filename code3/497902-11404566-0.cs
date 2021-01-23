    List<Process> processes = Process.GetProcesses().Where(p => p.ProcessName == "explorer").ToList();
    
    foreach (var process in processes)
    {
      process.Kill();
    }
