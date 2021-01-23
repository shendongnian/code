    private ObservableCollection<string> _myCollection = new ObservableCollection<string>();
    public ObservableCollection<string> MyCollection
    {
        get { return _myCollection; }
        set
        {
            if(_myCollection == value)
                return;
            _myCollection = value;
            RaisePropertyChanged("MyCollection");
        }
    }
