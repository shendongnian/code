    MonitorCollection monitors = MonitorConfig.GetConfig().Monitors;
    
    foreach (Monitor m in monitors)
    {
        Console.WriteLine(m.Description);
        if (m.Monitors != null && m.Monitors.Count > 0)
        {
            foreach (Monitor m1 in m.Monitors)
            {
                Console.WriteLine(m1.Description);
            }
        }
    }
