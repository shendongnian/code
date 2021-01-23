    private Stopwatch _stopwatch = new Stopwatch();
    public void TapHandler()
    {
      TimeSpan elapsed = _stopwatch.Elapsed;
      _stopwatch.Restart();
      if (elapsed < TimeSpan.FromSeconds(1)) {...}
    }
    
