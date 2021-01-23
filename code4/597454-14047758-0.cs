    var r = new Dictionary<string, string>();
    using (var pc = new PerformanceCounter("ASP.NET Applications", "Cache % Machine Memory Limit Used", true))
    {
        pc.InstanceName = "__Total__";
        r.Add("Total_MachineMemoryUsed", String.Concat(pc.NextValue().ToString("N1"), "%"));
    }
    using (var pc = new PerformanceCounter("ASP.NET Applications", "Cache % Process Memory Limit Used", true))
    {
        pc.InstanceName = "__Total__";
        r.Add("Total_ProcessMemoryUsed", String.Concat(pc.NextValue().ToString("N1"), "%"));
    }
    using (var pc = new PerformanceCounter("ASP.NET Applications", "Cache API Entries", true))
    {
        pc.InstanceName = "__Total__";
        r.Add("Total_Entries", pc.NextValue().ToString("N0"));
    }
    using (var pc = new PerformanceCounter("ASP.NET Applications", "Cache API Misses", true))
    {
        pc.InstanceName = "__Total__";
        r.Add("Total_Misses", pc.NextValue().ToString("N0"));
    }
    using (var pc = new PerformanceCounter("ASP.NET Applications", "Cache API Hit Ratio", true))
    {
        pc.InstanceName = "__Total__";
        r.Add("Total_HitRatio", String.Concat(pc.NextValue().ToString("N1"), "%"));
    }
    using (var pc = new PerformanceCounter("ASP.NET Applications", "Cache API Trims", true))
    {
        pc.InstanceName = "__Total__";
        r.Add("Total_Trims", pc.NextValue().ToString());
    }
