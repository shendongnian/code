    private readonly List<string> _strings = new List<string>();
    public IEnumerable<string> Strings 
    {
        get 
        {
            return _strings.Select(x => x);
        }
    }
