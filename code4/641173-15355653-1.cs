        using System.Data.Entity
        public IQueryable<LocationEntity> GetAll
        {
            get
            {
                return _context.Locations;
            }
        }
