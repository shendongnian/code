    private static void GetMeasure()
    {
    	process.Refresh();  // Updates process information
    
    	Console.WriteLine("{0,38} {1,20}", "Private bytes", "working set");
    	Console.WriteLine("process data{0,23} {1,20}", process.PrivateMemorySize64 / 1024, process.WorkingSet64 / 1024);
    	Console.WriteLine("PerformanceCounter data{0,12} {1,20}", privateBytesCounter.NextValue() / 1024, workingSetCounter.NextValue() / 1024);
    }
