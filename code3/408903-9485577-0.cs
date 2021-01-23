    // Wait X Sec  and then try to send message
    System.Timers.Timer t = new System.Timers.Timer();
    t.Interval = Convert.ToDouble(ConfigurationManager.AppSettings["timer"]);
    t.Elapsed += delegate { /*your function here */};
    t.Start();
    t.AutoReset = false; // do it once
