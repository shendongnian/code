    private void AcquirePushChannel()
    {
        CurrentChannel = HttpNotificationChannel.Find("MyPushChannel");
        if (CurrentChannel == null)
        {
            CurrentChannel = new HttpNotificationChannel("MyPushChannel");
        }
        if (CurrentChannel.ConnectionStatus == ChannelConnectionStatus.Disconnected)
        {
            CurrentChannel.Open();
        }
        if (!CurrentChannel.IsShellToastBound)
        {
            CurrentChannel.BindToShellToast();
        }
    }
