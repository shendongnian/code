    private bool displayXamlTab;
    public bool DisplayXamlTab
    {
        get { return this.displayXamlTab; }
        set
        {
            this.displayXamlTab = value;
            this.RaisePropertyChanged("DisplayXamlTab");
        }
    }
