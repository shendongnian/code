    private static void killProcessAndChildProcesses(Process[] processes, Process parent)
    {
        foreach (Process p in processes)
        {
            if (p.GetParentProcessId() == parent.Id)
            {
                p.Kill();
            }
        }
        parent.Kill()
    }
