    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    
    
    
    namespace Stackoverflow
    {
        public class PerfCounters
        {
            public static void Main()
            {
                var processorCategory = PerformanceCounterCategory.GetCategories()
                    .FirstOrDefault(cat => cat.CategoryName == "Processor");
                var countersInCategory = processorCategory.GetCounters("_Total");
                DisplayCounter(countersInCategory
                    .First(cnt => cnt.CounterName == "% Processor Time"));
                Console.Read();
            }
            private static void DisplayCounter(PerformanceCounter performanceCounter)
            {
                while (!Console.KeyAvailable)
                {
                    Console.WriteLine("{0}\t{1} = {2}",
                        performanceCounter.CategoryName
                        , performanceCounter.CounterName
                        , performanceCounter.NextValue());
                    Thread.Sleep(1000);
                }
            }
        }
    }
