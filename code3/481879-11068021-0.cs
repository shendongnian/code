    object lockObject = new object();
    List<Process> processesToRemove = new List<Process>();
    foreach (Process p in _runningProcesses)
    {
        foreach (ProcessModule module in p.Modules)
        {
            string[] strs = text.Split('\\');
            if (module.ModuleName.Equals(strs[strs.Length - 1]))
            {
                processesToRemove.Add(p);
                break;
            }
        }                    
    }                
    lock (lockObject)
    {
        foreach (Process p in processesToRemove)
        {                 
            p.Kill();
            _runningProcesses.Remove(p);
        }                
    }
