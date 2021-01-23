    // Put this somewhere in your console app/windows form initialization code.
    SystemEvents.SessionSwitch += OnSessionSwitch;
    // Put this method in your console app/windows form somewhere.
    static void OnSessionSwitch(object sender, SessionSwitchEventArgs e)
    {
      switch (e.Reason)
      {
        case SessionSwitchReason.SessionLogon:
          // User has logged on to the computer.
          break;
        case SessionSwitchReason.SessionLogoff:
          // User has logged off from the computer.
          break;
        case SessionSwitchReason.SessionUnlock:
          // The computer has been unlocked.
          break;
        case SessionSwitchReason.SessionLock:
          // The computer has been locked.
          break;
      }
    }
