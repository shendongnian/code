    class NumerousSettings
    {
        public string Path {get; set;};
        public string MainId  {get; set;};
        ...
    }
    public Sample(NumerousSettings settings)
    {
        if (settings == null)
        {
            throw new CallTheDefaultContructorException();
        }
        this.Path = settings.Path;
        this.PathID = settings.MainId;
        ...
        InitializeComponent();
    }
