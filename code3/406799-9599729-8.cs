    void m_loadTest_LoadTestStarting(object sender, System.EventArgs e)
    {        
        // Delete the category if already exists   
        if (PerformanceCounterCategory.Exists("CustomCounterSet"))
        {
            PerformanceCounterCategory.Delete("CustomCounterSet");
        }
    
        //Create the Counters collection and add my custom counters 
        CounterCreationDataCollection counters = new CounterCreationDataCollection();
        counters.Add(new CounterCreationData(Counters.RequestDelayTime.ToString(), "Keeps the actual request delay time", PerformanceCounterType.AverageCount64));
        // .... Add the rest counters
    
        // Create the custom counter category
        PerformanceCounterCategory.Create("CustomCounterSet", "Custom Performance Counters", PerformanceCounterCategoryType.MultiInstance, counters);
    }
