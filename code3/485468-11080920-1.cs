    SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
    SystemEvents.SessionEnded += new SessionEndedEventHandler(SystemEvents_SessionEnded);
    static void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
    {
        /// handle lock desktop and unlock here
    }
    static void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
    {
        /// handle log off here
    }
