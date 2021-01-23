    var processesToKill = new Collection<string> { "notepad", "taskmgr" };
    foreach (var process in Process.GetProcesses().Where(p => processesToKill.Contains(p)))
    {
        process.Kill();
    }
