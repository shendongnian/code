    public TimeSpan UpTime {
        get {
            using (var uptime = new PerformanceCounter("System", "System Up Time")) {
                uptime.NextValue();       //Call this an extra time before reading its value
                return TimeSpan.FromSeconds(uptime.NextValue());
            }
        }
    }
