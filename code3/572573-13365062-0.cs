    public List<string> Titles {
        get {
            return Keys
                .Select(k => k.ToString())
                .OrderBy(s => s)
                .ToList(); 
        }
    }
