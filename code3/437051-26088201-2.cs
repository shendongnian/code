    /// <summary>
    ///     Gets a dynamically populated list of DbSets within the context.
    /// </summary>
    /// <value>
    ///     A dynamically populated list of DbSets within the context.
    /// </value>
    [ImportMany(typeof(DbSet<IEntity>))]
    public IEnumerable<DbSet<IEntity>> Sets { get; private set; }
