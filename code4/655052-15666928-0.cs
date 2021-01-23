    public ZipEntry this[String fileName]
    {
        get
        {
            if (_entries.ContainsKey(fileName))
                return _entries[fileName];
            return null;
        }
    }
    public ICollection<ZipEntry> Entries
    {
        get { return _entries.Values; }
    }
    
