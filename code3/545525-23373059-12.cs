    /// <summary>
    ///     Adds functionality to all entities derived from the RecursiveEntity base class.
    /// </summary>
    public static class RecursiveEntityEx
    {
        /// <summary>
        ///     Adds a new child Entity to a parent Entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of recursive entity to associate with.</typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="child">The child.</param>
        /// <returns>The parent Entity.</returns>
        public static TEntity AddChild<TEntity>(this TEntity parent, TEntity child)
            where TEntity : RecursiveEntity<TEntity>
        {
            child.Parent = parent;
            if (parent.Children == null)
                parent.Children = new HashSet<TEntity>();
            parent.Children.Add(child);
            return parent;
        }
        /// <summary>
        ///     Adds child Entities to a parent Entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of recursive entity to associate with.</typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="children">The children.</param>
        /// <returns>The parent Entity.</returns>
        public static TEntity AddChildren<TEntity>(this TEntity parent, IEnumerable<TEntity> children)
            where TEntity : RecursiveEntity<TEntity>
        {
            children.ToList().ForEach(c => parent.AddChild(c));
            return parent;
        }
    }
