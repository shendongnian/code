    const int ChunkSize = 1024;
    public async Task<List<TK>> BulkDeleteAsync(List<TK> ids)
    {
        if (ids.Count < 1) {
            return new List<TK>();
        }
        // SOURCE: https://stackoverflow.com/a/20953521/11344051
        var chunks = ids.Chunks(ChunkSize).Select(c => c.ToList()).ToList();
        var tableName = DbContext.GetTableName<T>();
        var deletedIds = new List<TK>();
        foreach (var chunk in chunks) {
            var sql = $@"
                DELETE FROM {tableName}
                OUTPUT Deleted.Id
                WHERE Id IN({string.Join(", ", chunk)});
            ";
            deletedIds.AddRange(DbContext.Database.SqlQuery<TK>(sql).ToListAsync());
        }
        return deletedIds;
    }
