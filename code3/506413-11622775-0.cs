    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        if (timer.Enabled)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        }
    }
