    public async Task<IEnumerable<Type>> GetTypeSet(Expression<Func<Type, bool>> predicate)
    {
        return await(dbSet.Where(d => d.isPublic == true)
        .Where(predicate)).ToListAsync();
    }
