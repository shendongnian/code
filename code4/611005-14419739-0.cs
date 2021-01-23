    SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
    void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
    {
      switch (e.Reason)
      {
        case SessionSwitchReason.SessionLogon:
          logTextBox.AppendText("User has logged on to the computer.\n");
          break;
        case SessionSwitchReason.SessionLogoff:
          logTextBox.AppendText("User has logged off from the computer.\n");
          break;
        case SessionSwitchReason.SessionUnlock:
          logTextBox.AppendText("The computer has been unlocked.\n");
          break;
        case SessionSwitchReason.SessionLock:
          logTextBox.AppendText("The computer has been locked.\n");
          break;
      }
    }
