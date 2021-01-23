    idleTimer = new DispatcherTimer();
    idleTimer.Interval = TimeSpan.FromMinutes(1);
    idleTimer.Tick += new EventHandler(idleTimer_Tick);
    // Initialise last activity time
    timeOfLastActivity = DateTime.Now;
