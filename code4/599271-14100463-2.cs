    private List<string> _list = new List<string>();
    public ReadOnlyCollection<string> List
    {
        get { return _list.AsReadOnly(); }
    }
