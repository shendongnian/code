    public Directory this[string name]
    {
        get { return SubDirectories.ContainsKey("name") ? SubDirectories[key] : null; }
        set { SubDirectories.Add(name, value); }
    }
