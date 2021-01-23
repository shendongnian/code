    private ObservableCollection<String> pathList = new ObservableCollection<string>();
    public ObservableCollection<String> FilePathList
    {
        get { return pathList; }
        set
        {
            if (value != pathList)
            {
                pathList = value;
                Notify("FilePathList"); // changed here
            }
        }
    }
