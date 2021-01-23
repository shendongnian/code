        /// <summary>
        /// Gets or sets the job levels.
        /// </summary>
        /// <value>
        /// The job levels.
        /// </value>
        [Export("Sets", typeof(DbSet<object>))]
        public DbSet<JobLevel> JobLevels { get; set; }
