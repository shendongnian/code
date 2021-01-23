    public async Task<IEnumerable<String>> SelectDistinctGroupNames()
    {
        var db = new SQLiteAsyncConnection(SQLitePath);
        var allLocations = await db.QueryAsync<SOs_Locations>("SELECT * FROM SOs_Locations");
        return allLocations.Select(x=>x.GroupName).Distinct();
    }
