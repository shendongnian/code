    public List<T> GetLogProperties<T>(Expression<Func<Log, T>> selector)
    {
    	return _db.Logs.Select(selector).Distinct().ToList();
    }
    
    public List<string> GetLevels()
    {
    	return GetLogProperties(l => l.Level);
    }
