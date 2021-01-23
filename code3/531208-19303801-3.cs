    public IEnumerable<Release> Releases
    {
        get
        {
            return new List<Release>(releases).AsReadOnly();
        }
        protected set
        {
            releases = value;
        }
    }
