    protected void OnNewFileAdded(List<string> data)
    {
        var localCopy = NewFileAdded;
        if (localCopy != null)
        {
            localCopy(this, new ListEventArgs(data));
        }
    }
