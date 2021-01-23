    PerformanceCounter performanceCounter = new PerformanceCounter();
    performanceCounter.CategoryName = "Process";
    performanceCounter.CounterName = "Working Set";
    performanceCounter.InstanceName = Process.GetCurrentProcess().ProcessName;
    Console.WriteLine(((uint)performanceCounter.NextValue()/1024).ToString("N0"));
