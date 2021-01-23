    public TimeSpan Elapsed
    {
      get
      {
        return new TimeSpan(this.GetElapsedDateTimeTicks());
      }
    }
    public long ElapsedMilliseconds
    {
      get
      {
        return this.GetElapsedDateTimeTicks() / 10000L;
      }
    }
