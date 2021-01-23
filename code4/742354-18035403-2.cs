    public IEnumerable<PercConfigEntry> GetPercConfigEntries() 
    {
        var results = 
            (from g in this.context.PercConfigEntry
             where g.Key == "ConfigEntries"
             select g)
            .AsEnumerable()
            .OrderBy(g => g.ConfigName);
        return results;
    }
