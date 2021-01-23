    private static PerformanceCounter cpuCounter;
    private static PerformanceCounter memoryCounter;
       
    [...]
    cpuCounter = new PerformanceCounter
    {
       CategoryName = "Processor",
       CounterName = "% Processor Time",
       InstanceName = "_Total"
    };
    memoryCounter = new PerformanceCounter
    {
        CategoryName = "Memory",
        CounterName = "Available Bytes"
    };
    [...]
    public double CpuUsage
    {
       get
       {
          lock (lockToken)
          {
              return Math.Round(cpuCounter.NextValue(), 2);
          }
       }
     }
     public double MemoryUsage
     {
        get
        {
           lock (lockToken)
           {
              return Math.Round(memoryCounter.NextValue() / totalMemory * 100, 2);
           }
        }
      }
