    /// <summary>
    ///     Provides extension methods for DbSet objects.
    /// </summary>
    public static class DbSetEx
    {
        /// <summary>
        ///     Truncates the specified set.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="set">The set.</param>
        /// <returns>The truncated set.</returns>
        public static DbSet<TEntity> Truncate<TEntity>(this DbSet<TEntity> set)
            where TEntity : class, IEntity
        {
            set.ToList().ForEach(p => set.Remove(p));
            return set;
        }
    }
