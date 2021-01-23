    static Program
    {
        private static PerformanceCounter cpuCounter = new PerformanceCounter() { 
            CategoryName = "Processor", 
            CounterName = "% Processor Time", 
            InstanceName = "_Total" };
        static void Main()
        {
            cpuCounter.NextValue();
            // Do your processing here.
            float totalCpuUsagePercentage = cpuCounter.NextValue();
        }
    }
