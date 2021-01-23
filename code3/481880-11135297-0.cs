    //Somewhere that is accessible to both the thread getting the process list and the thread the 
    //code below will be running, declare your sync, lock while adjusting _runningProcesses
    public static readonly object Sync = new object();
    IList<Process> runningProcesses;
    lock(Sync)
    {
        runningProcesses = _runningProcesses.ToList();
    }
    Process processToRemove = null;
    foreach (Process p in _runningProcesses)
    {
        foreach (ProcessModule module in p.Modules)
        {
            string[] strs = text.Split('\\');
            if (module.ModuleName.Equals(strs[strs.Length - 1]))
            {
                processToRemove = p;
                break;
            }
        }
        if (processToRemove != null)
        {
            break;
        }
    }
    if (processToRemove != null)
    {
        //If we've got a process that needs killing, re-lock on Sync so that we may 
        //safely modify the shared collection
        lock(Sync)
        {
            processToRemove.Kill();
            _runningProcesses.Remove(processToRemove);
        }
    }
