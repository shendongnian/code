    private void timer_Tick(object sender, EventArgs e)
    {
        if (eventLastTriggered.HasValue
            && (DateTime.Now - eventLastTriggered.Value) >= UpdateDelay)
        {
            eventLastTriggered = null; // reset it so we don't update again
            Update();
        }
    }
    static readonly TimeSpan UpdateDelay = TimeSpan.FromMilliseconds(whatever);
