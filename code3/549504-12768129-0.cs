    private static void LoadBLG(string CounterPath)
            {
                PowerShell ps = PowerShell.Create();
                ps.AddCommand("import-counter");
                ps.AddArgument(CounterPath);
    
                Console.WriteLine(CounterPath);
                Console.WriteLine("------------------------");
    
                foreach (PSObject result in ps.Invoke())
                {
                    if (result.ImmediateBaseObject is PerformanceCounterSampleSet)
                    {
                        PerformanceCounterSampleSet Counters = result.ImmediateBaseObject as PerformanceCounterSampleSet;
                        foreach (PerformanceCounterSample sample in Counters.CounterSamples)
                            Console.WriteLine("{0,-20}{1}",
                                sample.Path, sample.RawValue);
                    }
                } // End foreach.
