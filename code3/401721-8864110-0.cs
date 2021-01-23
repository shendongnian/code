    static void ProcessSID(Process process)
    {
        string sid;
        ExGetProcessInfoByPID(process.Id, out sid);
        Console.WriteLine("{0} {1} {2}", process.Id, process.ProcessName, sid);
    }
    static void Main(string[] args)
    {
        foreach (Process process in Process.GetProcesses())
        {
            ProcessSID(process);
        }
    }
