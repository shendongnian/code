    private IList<String> _pathList = new ObservableCollection<string>();
    public IList<String> filePathList
    {
        get { return _pathList; }
        set
        {
            if (value != _pathList)
            {
                _pathList = value;
                Notify("filePathList");
            }
        }
    }
