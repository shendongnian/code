    private static TimeSpan GetUptime()
    {
        // Try and set the Uptime using per counters
        var helper = new Helper();
        var uptimeThread = new Thread(helper.GetPerformanceCounterUptime);
        uptimeThread.Start();
    
        // If our thread hasn't finished in 5 seconds, perf counters are broken
        if (uptimeThread.Join(5 * 1000))
        {
            return helper._uptime;
        } else {
            // Kill the thread and use Environment.TickCount
            uptimeThread.Abort();
            return TimeSpan.FromMilliseconds(
                Environment.TickCount & Int32.MaxValue);
        }
    }
    class Helper
    {
        internal TimeSpan _uptime;
    
        // This sets the System uptime using the perf counters
        // this gives the best result but on a system with corrupt perf counters
        // it can freeze
        internal void GetPerformanceCounterUptime()
        {
            using (var uptime = new PerformanceCounter("System", "System Up Time"))
            {
                uptime.NextValue();
                _uptime = TimeSpan.FromSeconds(uptime.NextValue());
            }
        }
    }
