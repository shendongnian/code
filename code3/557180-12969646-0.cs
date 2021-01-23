    private void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
    {
        if (e.Reason == SessionEndReasons.Logoff)
        {
            //this may sleep the system even when user logs off manually.
            Application.SetSuspendState(PowerState.Suspend, true, true);
        }
    }
