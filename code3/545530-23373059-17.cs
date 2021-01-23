    /// <summary>
    ///     Acts as a base class for all recursively hierarchical entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class RecursiveEntity<TEntity> : Entity, IRecursiveEntity<TEntity> 
        where TEntity : RecursiveEntity<TEntity>
    {
        #region Implementation of IRecursive<TEntity>
        /// <summary>
        ///     Gets or sets the parent item.
        /// </summary>
        /// <value>
        ///     The parent item.
        /// </value>
        public virtual TEntity Parent { get; set; }
        /// <summary>
        ///     Gets or sets the child items.
        /// </summary>
        /// <value>
        ///     The child items.
        /// </value>
        public virtual ICollection<TEntity> Children { get; set; }
        #endregion
    }
