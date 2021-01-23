    public static Process GetParent(Process process)
    {
        var processName = process.ProcessName;
        var nbrOfProcessWithThisName = Process.GetProcessesByName(processName).Length;
        for (var index = 0; index < nbrOfProcessWithThisName; index++)
        {
            var processIndexdName = index == 0 ? processName : processName + "#" + index;
            var processId = new PerformanceCounter("Process", "ID Process", processIndexdName);
            if ((int)processId.NextValue() == process.Id)
            {
                var parentId = new PerformanceCounter("Process", "Creating Process ID", processIndexdName);
                return Process.GetProcessById((int)parentId.NextValue());
            }
        }
        return null;
    }
