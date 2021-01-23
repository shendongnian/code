    public IList<string> FileList
    {
        get { return _fileList.Select(file => String.Empty + file).ToList(); }
        set { _fileList = value; } 
    }
