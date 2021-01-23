    public UserService : BaseService<UserRepository>
    {
        public UserService() : base(new DAL.UserRepository())
        {
            // base.Repository is now a UserRepository.
        }    
    }
