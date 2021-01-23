    private DateTime _lastTap;
    public void TapHandler()
    {
      DateTime now = DateTime.UtcNow;
      TimeSpan span = now - lastTap;
      _lastTap = now;
      if (span > TimeSpan.Seconds(1)) {...}
    }
