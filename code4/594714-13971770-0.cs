    List<string> blackList = new List<string>();
    // TODO: Populate the list with "black listed" processes
    // Kill any process which is in the blacklist
    foreach (Process process in Process.GetProcesses())
    {
        if (blackList.Any(x => x.ToLowerInvariant().Equals(process.ProcessName.ToLowerInvariant())))
        {
            process.Kill();
        }
    }
