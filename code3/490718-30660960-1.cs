    private ObservableCollection<WrappedNode> _nodeList;
    public ObservableCollection<WrappedNode> NodeList
    {
        get { return _nodeList; }
        set
        {
            _nodeList = value;
            RaisePropertyChanged(() => NodeList);
        }
    }
