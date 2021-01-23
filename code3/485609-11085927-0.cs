    private List<Claimant> _drivers = new List<Claimamt>();  // Option 1
    
    public MyModel()
    {
        _drivers = new List<Claimant>();   // Option 2
    }
    
    public IEnumerable<Claimant> Drivers
    {
        get
        {
            return _drivers ?? (_drivers = new List<Claimant>()); // Option 3
        }
        set
        {
            _drivers = value;
        }
    }
