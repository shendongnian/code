    PerformanceCounterCategory pcc = new PerformanceCounterCategory();
    
    // Retrieves the list of performance object instances that are associated with this category.
    foreach (string instanceName in pcc.GetInstanceNames()) 
        // Retrieves a list of the counters in a performance counter category that contains exactly one instance.
    	foreach (PerformanceCounter counter in pcc.GetCounters())
    	{
    		// now you have the counter object that represents a PerformanceCounter to get some information about the performance counter
    	
    		Console.WriteLine("Category: " + counter.Category);
    		Console.WriteLine("Instance Name: " + counter.InstanceName);	
    		Console.WriteLine("Machine Name: " + counter.MachineName);
    		
    		Console.WriteLine("Counter Name: " + counter.CounterName);
    		
    		Console.WriteLine("Next Value: " + counter.NextValue());
    	}
