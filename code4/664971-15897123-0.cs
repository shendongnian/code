    private string selectedCommand;
    
    public string SelectedCommand
    {
        get
        {
            return selectedCommand;
        }
        set
        {
            selectedCommand = value;
            NotifyPropertyChanged("SelectedCommand");
        }
    }
