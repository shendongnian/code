        public DbSet<LocationEntity> GetAll
        {
            get
            {
                return _context.Locations;
            }
        }
