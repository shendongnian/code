    /// <summary>
    ///     Represents a recursively hierarchical Entity.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRecursiveEntity <TEntity> where TEntity : IEntity
    {
        /// <summary>
        ///     Gets or sets the parent item.
        /// </summary>
        /// <value>
        ///     The parent item.
        /// </value>
        TEntity Parent { get; set; }
        /// <summary>
        ///     Gets or sets the child items.
        /// </summary>
        /// <value>
        ///     The child items.
        /// </value>
        ICollection<TEntity> Children { get; set; }
    }
