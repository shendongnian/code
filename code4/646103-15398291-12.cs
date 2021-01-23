        public DbSet<UserProfile> UserProfiles { get; set; }
        IQueryable<UserProfile> IDataSource.UserProfiles
        {
            get { return UserProfiles; }
        }
