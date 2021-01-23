    static void SystemEvents_TimeChanged(object sender, EventArgs e)
    {
        SystemEvents.TimeChanged -= new EventHandler(SystemEvents_TimeChanged);
        Console.WriteLine("Time changed: {0}", DateTime.Now);
    }
