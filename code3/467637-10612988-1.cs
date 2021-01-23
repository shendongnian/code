    using System.Diagnostics;
    int GetInstanceCount(ExeName)
    {
        Process[] processlist = Process.GetProcessesByName(ExeName);
        int NoOfInstances = processlist.Count;
        return NoOfInstances;
    }
