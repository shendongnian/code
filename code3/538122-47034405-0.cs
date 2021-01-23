    private IEnumerable<TEntity> GetList<TEntity>(string connectionString, Func<object, T> caster)
    {
        using (var ctx = new DbContext(connectionString))
        {
            var setMethod = ctx.GetType().GetMethod("Set").MakeGenericMethod(typeof(T));
            var querable = ((DbSet<object>)setMethod
            .Invoke(this, null))
            .AsNoTracking()
            .AsQueryable();
            return querable
                .Select(x => caster(x))
                .ToList();
        }
    }
