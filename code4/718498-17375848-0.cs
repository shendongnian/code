    Process[] processlist = Process.GetProcesses();
    foreach(Process theprocess in processlist)
    {
        string strongName = "N/A";
        try
        {
            strongName = Assembly.ReflectionOnlyLoadFrom(theprocess.MainModule.FileName).FullName;
        }
        catch
        {
            // System process?
        }
        Console.WriteLine("Process: {0} ID: {1} Strong Name: {2}", theprocess.ProcessName, theprocess.Id, strongName);
