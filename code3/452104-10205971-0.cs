    private ObservableCollection<CatSummary> _myOC = new ObservableCollection<CatSummary>();
    public ObservableCollection<CatSummary> MyOC
    {
        get { return _myOC ; }
        set { if (_myOC != value) { _myOC = value; NotifyPropertyChanged("MyOC"); } }
    }
