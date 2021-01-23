        [Queryable]
        public IQueryable<DatabaseProductDTO> GetDatabaseProductDTO(ODataQueryOptions<DatabaseProductDTO> options)
        {
            // _db.DatabaseProducts is an EF table 
            // DatabaseProductDTO is my DTO object
            var projectedDTOs = _db.DatabaseProducts.Project().To<DatabaseProductDTO>();
            var settings = new ODataQuerySettings();
            var results = (IQueryable<DatabaseProductDTO>) options.ApplyTo(projectedDTOs, settings);
            return results.ToArray().AsQueryable();
        }
