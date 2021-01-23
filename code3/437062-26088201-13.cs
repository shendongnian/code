        #region Dynamic Table List
        /// <summary>
        ///     Gets a dynamically populated list of DbSets within the context.
        /// </summary>
        /// <value>
        ///     A dynamically populated list of DbSets within the context.
        /// </value>
        public List<DbSet<IEntity>> Tables { get; private set; }
        /// <summary>
        ///     Gets a dynamically populated list of DbSets within the context.
        /// </summary>
        /// <value>
        ///     A dynamically populated list of DbSets within the context.
        /// </value>
        [ImportMany("Sets", typeof (DbSet<object>), AllowRecomposition = true)]
        private List<object> TableObjects { get; set; }
        /// <summary>
        ///     Composes the sets list.
        /// </summary>
        /// <remarks>
        ///     To make this work, you need to import the DbSets into a temporary collection of
        ///     DbSet of type "object", then cast this collection to DbSet of your required
        ///     interface type. For basic purposes, the IEntity interface will suffice.
        /// </remarks>
        private void ComposeSetsList()
        {
            // Instantiate the list of tables.
            Tables = new List<DbSet<IEntity>>();
            // Instantiate the MEF Import collection.
            TableObjects = new List<object>();
            // Create a new Types catalogue, to hold the exported parts.
            var catalogue = new TypeCatalog(typeof (DbSet<object>));
            // Create a new Composition Container, to match all the importable and imported parts.
            var container = new CompositionContainer(catalogue);
            // Compose the exported and imported parts for this class.
            container.ComposeParts(this);
            // Safe cast each DbSet<object> to the public list as DbSet<IEntity>.
            TableObjects.ForEach(p => Tables.Add(p as DbSet<IEntity>));
        }
        #endregion
