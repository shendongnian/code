    public ProfileRepository : IProfileRepository
    {
        private IMyEntitiesContext _ctx;
     
        public ProfileRepository(IMyEntitiesContext ctx)
        {
            _ctx = ctx;
        }
    }
