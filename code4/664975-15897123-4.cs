    private Command selectedCommand;
    public Command SelectedCommand
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
