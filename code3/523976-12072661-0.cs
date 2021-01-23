    private decimal? _currentImpulseId;
    // ... later on used in public property getter as follows
    
    public decimal? CurrentImpulseId
    {
      get { return _currentImpulseId ?? 0M; }
      set { _currentImpulseId = value; }
    }
 
