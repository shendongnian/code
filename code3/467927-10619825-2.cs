    private BlockingCollection<Process[]> queue = new BlockingCollection<Process[]>();
    public void FillTable()
    {
        while (true)
        {
             Thread.Sleep(interval);
             queue.Add(Process.GetProcesses());
        }
    }
    public void GetGeneralInfo()
    {
        while (true)
        {
            Process[] processes = queue.Take();
            Console.WriteLine(processes.Length.ToString());
        }
    }
