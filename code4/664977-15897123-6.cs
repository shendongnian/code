    private ObservableCollection<Command> selectedCommands;
    public ObservableCollection<Command> SelectedCommands
    {
        get
        {
            return selectedCommands;
        }
        set
        {
            selectedCommands = value;
            NotifyPropertyChanged("SelectedCommands");
        }
    }
