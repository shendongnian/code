    System.Threading.Timer timer = new System.Threading.Timer(new TimerCallback(TimerElapsed), null, new Timespan(0), new Timespan(24, 0, 0));
    // This will run every 24 hours.
    private void TimerElapsed(object o)
    {
        // Do stuff.
    }
