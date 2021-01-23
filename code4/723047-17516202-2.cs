    private ObservableCollection<string> names;
    public ObservableCollection<string> Names
    {
        get { return names; }
        set { names = value; RaisePropertyChanged("Names"); }
    }
