    private bool sBaseCheck;
    public bool BaseCheck
    {
        get { return this.sBaseCheck; }
        set
        {
            this.sBaseCheck = value;                
            Generatelabels(this)
            this.OnPropertyChanged("BaseCheck");
        }
    }
