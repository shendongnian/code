    private IEnumerable<Claimant> _drivers;
    public IEnumerable<Claimant> Drivers
    {
        get
        {
            return _drivers ?? (_drivers = Enumerable.Empty<Claimant>());
        }
        set
        {
            _drivers = value;
        }
    }
