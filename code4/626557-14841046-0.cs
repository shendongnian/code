    [Inject]
    public TLPContext()
       : base("DefaultConnection")
    {
       this.Configuration.LazyLoadingEnabled = false;
    }
