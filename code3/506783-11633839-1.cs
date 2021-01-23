    //Create the counters data. You could also use a loop here if your counters will have exactly these names.
    CounterCreationDataCollection counters = new CounterCreationDataCollection();
    counters.Add(new CounterCreationData("CounterName1", "Description of Counter1", PerformanceCounterType.AverageCount64));
    counters.Add(new CounterCreationData("CounterName2", "Description of Counter2", PerformanceCounterType.AverageCount64));
    //Create the category with the prwviously defined counters.
    PerformanceCounterCategory.Create("CategoryName", "CategoryDescription", PerformanceCounterCategoryType.MultiInstance, counters);
    //Create the Instances
    CategoryName actions = new PerformanceCounter("CategoryName", "CounterName1", "Instance1", false));
    CategoryName tests = new PerformanceCounter("CategoryName", "CounterName2", "Instance1", false));
