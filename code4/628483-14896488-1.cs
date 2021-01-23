    protected void OnClocknameReceived(Clock.ClocknameReceivedEventArgs e)
    {
        ClockClocknameReceivedEventHandler handler = ClocknameReceived;
        if (handler != null)
        {
            handler(this, e);
        }
    }
