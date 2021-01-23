    public IEnumerable<PercConfigEntry> GetPercConfigEntries() 
    {
        var results = this.context.PercConfigEntry
            .Where(g => g.Key == "ConfigEntries")
            .AsEnumerable()
            .OrderBy(g => g.ConfigName);
        return results;
    }
