    private bool GotAMessage = false;
    void MessageReceived()
    {
        // happens whenever a message is received
        GotAMessage = true;
    }
    void OnTimerExpired(object state)
    {
        if (!GotAMessage)
        {
            // didn't receive a message in time.
        }
        GotAMessage = false;
    }
