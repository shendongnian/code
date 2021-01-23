    _myDataSourceTask = MyDataSource.Create();
    …
    public static async Task<MyDataGroup> GetGroup(string uniqueId)
    {
        var myDataSource = await _myDataSourceTask;
        // Simple linear search is acceptable for small data sets
        var matches = myDataSource.AllGroups.Where(group => group.UniqueId == uniqueId);
        if (matches.Count() == 1) return matches.First();
        return null;
    }
