    public static void SetModified<TEntity>(
            this DbEntityEntry<TEntity> entry,
            params Expression<Func<TEntity, object>>[] expressions) where TEntity : class, IEntity
        {
            foreach (var expression in expressions)
                entry.Property(expression).IsModified = true;
        }
