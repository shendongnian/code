    public event PropertyChangedEventHandler PropertyChanged;
    // Create the OnPropertyChanged method to raise the event 
    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
    public Visibility ErrorPanelVisibility 
    {
        get { return this._errorPanelVisibility; }
        set
        {
            if (this._errorPanelVisibility == value)
            {
                return;
            }
    
            this._errorPanelVisibility = value;
            OnPropertyChanged("ErrorPanelVisibility");
        }
    }
