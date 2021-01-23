     #region Constructors
    
        /// <summary>
        /// Initializes a new FrameworkEntities object using the connection string found in the 'FrameworkEntities' section of the application configuration file.
        /// </summary>
        public FrameworkEntities() : base("name=FrameworkEntities", "FrameworkEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            this.CommandTimeout = 300;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new FrameworkEntities object.
        /// </summary>
        public FrameworkEntities(string connectionString) : base(connectionString, "FrameworkEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            this.CommandTimeout = 300;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new FrameworkEntities object.
        /// </summary>
        public FrameworkEntities(EntityConnection connection) : base(connection, "FrameworkEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            this.CommandTimeout = 300;
            OnContextCreated();
        }
    
        #endregion
