    private static readonly Lazy<MethodInfo> internalDeleteMethod = new Lazy<MethodInfo>(
        () => typeof(ObjectContext).Assembly.GetType("System.Data.Objects.EntityEntry").GetMethod("Delete", BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(bool) }, null)); 
    public static void Delete<TEntity>(Func<DbContext> dbContextFactory, TEntity entity,
        Func<DbContext, IEnumerable<DbEntityValidationResult>> onSaving = null,
        Action<DbContext> onSaved = null,
        bool referenceFixup = true)
            where TEntity : class
    {
        Guard.ArgumentNotNull(dbContextFactory, "dbContextFactory");
        Guard.ArgumentNotNull(entity, "entity");
        onSaving = onSaving ?? (_ => null);
        onSaved = onSaved ?? (_ => { });
        using (var dbContext = dbContextFactory())
        {
            var set = dbContext.Set<TEntity>();
            set.Attach(entity);
            var entry = ((IObjectContextAdapter)dbContext).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
            internalDeleteMethod.Value.Invoke(entry, new object[] { referenceFixup });
            dbContext.SaveChanges();
         }
     }
