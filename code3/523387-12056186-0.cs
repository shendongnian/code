    using System;
    using System.Configuration;
    using System.Diagnostics;
    namespace TEST
    {
        // sample implementation
        public static class PerformanceHelper
        {
            // update a performance counter value
            public static void UpdateCounter(string WebMethodName, int count)
            {
                // to be able to turn the monitoring on or off
                if (ConfigurationManager.AppSettings["PerformanceMonitor"].ToUpper() == "TRUE")
                {
                    PerformanceCounter counter;
                    if (!PerformanceCounterCategory.Exists("SAMPLE"))
                    {
                        CounterCreationDataCollection listCounters = new CounterCreationDataCollection();
                        CounterCreationData newCounter = new CounterCreationData(WebMethodName, WebMethodName, PerformanceCounterType.NumberOfItems64);
                        listCounters.Add(newCounter);
                        PerformanceCounterCategory.Create("SAMPLE", "DESCRIPTION", new PerformanceCounterCategoryType(), listCounters);
                    }
                    else
                    {
                        if (!PerformanceCounterCategory.CounterExists(WebMethodName, "SAMPLE"))
                        {
                            CounterCreationDataCollection rebuildCounterList = new CounterCreationDataCollection();
                            CounterCreationData newCounter = new CounterCreationData(WebMethodName, WebMethodName, PerformanceCounterType.NumberOfItems64);
                            rebuildCounterList.Add(newCounter);
                            PerformanceCounterCategory category = new PerformanceCounterCategory("SAMPLE");
                            foreach (var item in category.GetCounters())
                            {
                                CounterCreationData existingCounter = new CounterCreationData(item.CounterName, item.CounterName, item.CounterType);
                                rebuildCounterList.Add(existingCounter);
                            }
                            PerformanceCounterCategory.Delete("SAMPLE");
                            PerformanceCounterCategory.Create("SAMPLE", "DESCRIPTION", new PerformanceCounterCategoryType(), rebuildCounterList);
                        }
                    }
                    counter = new PerformanceCounter("SAMPLE", WebMethodName, false);
                    if (count == -1)
                        counter.IncrementBy(-1);
                    else
                        counter.IncrementBy(count);
                }
            }
        }
    }
