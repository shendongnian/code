    public async Task<List<String>> SelectDistinctGroupNames()
    {
      var db = new SQLiteAsyncConnection(SQLitePath);
      var result = await db.QueryAsync<DistinctGroupNamesResult>("SELECT DISTINCT GroupName FROM SOs_Locations");
      return result.Select(x => x.GroupName).ToList();
    }
