    // Timestamp of last update time
    // Default to very old timestamp on init so it always runs once straight away
    private DateTime lastDBUpdate = DateTime.MinValue;
    private void GPS_PositionReceived(string Lat, string Lon)
    {
        // Throttle this method
        if(DateTime.Now.Subtract(lastDBUpdate).TotalSeconds < 5) return;
        // your existing code
        // Update the timestamp 
        lastDBUpdate = DateTime.Now;
    }
