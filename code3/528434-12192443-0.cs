    private void OnElapsedTime(object source, ElapsedEventArgs e)
    {
        sc.Refresh();
        if (sc.Status == ServiceControllerStatus.StartPending ||
            sc.Status == ServiceControllerStatus.Stopped)
        {
            StartPs();
        }
    }
