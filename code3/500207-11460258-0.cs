    PerformanceCounter cpuCounter;
    PerformanceCounter ramCounter;
    
    cpuCounter = new PerformanceCounter();
    
    cpuCounter.CategoryName = "Processor";
    cpuCounter.CounterName = "% Processor Time";
    cpuCounter.InstanceName = "_Total";
    
    ramCounter = new PerformanceCounter("Memory", "Available MBytes");
    
    
    public string getCurrentCpuUsage(){
                return cpuCounter.NextValue()+"%";
    }
    
    public string getAvailableRAM(){
                return ramCounter.NextValue()+"MB";
    } 
