    private bool createTrigger;
    public bool CreateTrigger
    {
        get { return createTrigger; }
        set { createTrigger = value; NotifyPropertyChanged(m => m.CreateTrigger); }
    }
