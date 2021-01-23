    var cpuCounter = new PerformanceCounter();
    cpuCounter.CategoryName = "Process";
    cpuCounter.CounterName = "% Processor Time";            
    cpuCounter.InstanceName = "taskmgr";
    cpuCounter.NextValue();
