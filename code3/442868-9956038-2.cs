    public static void UpdatePacket<TEntity>(Expression<Func<TEntity, bool>> filter, Action<TEntity> update)
    {
        using (var ctx = new DataContext())
        {
            var e = ctx.GetTable<TEntity>().Single(filter);
            update(e);
            ctx.SubmitChanges();
        }
    }
