    private static Process RunningInstance()
    {
        var current = Process.GetCurrentProcess();
        var procName = current.ProcessName.Replace(@".vshost", string.Empty);
        var processes = Process.GetProcessesByName(procName);
        return processes.FirstOrDefault(t => t.Id != current.Id && current.SessionId == t.SessionId);
    }
