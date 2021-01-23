    public Host SelectedHost {
        get;
        set {
            SelectedHost = value;
            UpdateLogData();
            OnPropertyChanged("SelectedHost");
        }
