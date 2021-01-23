            try
            {                
                const string _categoryName = "MyPerformanceCounter";
                if (!PerformanceCounterCategory.Exists(_categoryName))
                {
                    CounterCreationDataCollection counters = 
                    new CounterCreationDataCollection();
    
                    CounterCreationData ccdWorkingThreads = new CounterCreationData();
                    ccdWorkingThreads.CounterName = "# working threads";
                    ccdWorkingThreads.CounterHelp = "Total number of operations executed";
                    ccdWorkingThreads.CounterType = PerformanceCounterType.NumberOfItems32;
                    counters.Add(ccdWorkingThreads);
    
                    // create new category with the counters above
                    PerformanceCounterCategory.Create(_categoryName,
                            "Performance counters of my app",
                            PerformanceCounterCategoryType.SingleInstance,
                            counters);
                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString()); //Do necessary action
            }   
