    void CreateCounter() 
    {
        if (PerformanceCounterCategory.Exists("MyCounters"))
        {
            PerformanceCounterCategory.Delete("MyCounters");
        }
    
        //Create the Counters collection and add your custom counters 
        CounterCreationDataCollection counters = new CounterCreationDataCollection();
        // The name of the counter is Delay
        counters.Add(new CounterCreationData("Delay", "Keeps the actual delay", PerformanceCounterType.AverageCount64));
        // .... Add the rest counters
    
        // Create the custom counter category
        PerformanceCounterCategory.Create("MyCounters", "Custom Performance Counters", PerformanceCounterCategoryType.MultiInstance, counters);
    }
