    private ObservableCollection<string> _alleBenutzer;
    public ObservableCollection<string> alleBenutzer
    {
        get
        {
            return _alleBenutzer;
        }
        set
        {
            _alleBenutzer= value;
            RaisePropertyChanged("alleBenutzer");
        }
    }
