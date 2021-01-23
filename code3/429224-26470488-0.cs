    public UInt64 CPULoad()
    {
        List<UInt64> list = new List<UInt64>();
        Thread thread = new Thread(() =>
        {
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject result in results)
            {
                list.Add((UInt64)result.Properties["PercentProcessorTime"].Value);
            }
        });
        thread.Start();
        thread.Join();
        return list.Max();
    }
