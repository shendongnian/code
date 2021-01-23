    idleTimer = new DispatcherTimer();
    idleTimer.Interval = TimeSpan.FromSeconds(1);
    idleTimer.Tick += new EventHandler(idleTimer_Tick);
    // Initialise last activity time
    timeOfLastActivity = DateTime.Now;
