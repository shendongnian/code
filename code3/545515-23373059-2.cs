    /// <summary>
    ///     Acts as a base class for all entities used with Entity Framework Code First.
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public int Id { get; set; }
    }
