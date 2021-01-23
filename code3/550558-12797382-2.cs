    private void Callback( Object state )
    {
        // Long running operation
       _timer.Change( TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite );
    }
