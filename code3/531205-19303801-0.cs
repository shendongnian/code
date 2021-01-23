    public List<Release> Releases
    {
        get
        {
            return new List<Release>(releases); //I can protect 'releases' when reading by passing a copy of it
        }
        protected set
        {
            releases = value; //BUT how can I protect release when writing?
        }
    }
