    public async Task<List<String>> SelectDistinctGroupNames()
    {
        var db = new SQLiteAsyncConnection(SQLitePath);
        var groupNames = await db.QueryAsync<string>("SELECT DISTINCT GroupName FROM SOs_Locations");
        return groupNames .ToList();
    }
