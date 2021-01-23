    public async Task<List<TK>> BulkDeleteAsync(List<TK> ids)
    {
        if (ids.Count < 1) {
            return new List<TK>();
        }
    
        // NOTE: DbContext here is a property of Repository Class
        // SOURCE: https://stackoverflow.com/a/9775744
        var tableName = DbContext.GetTableName<T>();
        var sql = $@"
            DELETE FROM {tableName}
            OUTPUT Deleted.Id
            // NOTE: Be aware that 'Id' column naming depends on your project conventions
            WHERE Id IN({string.Join(", ", ids)});
        ";
        return await @this.Database.SqlQuery<TK>(sql).ToListAsync();
    }
