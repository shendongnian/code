    public BaseService<T> where T : IRepository
    {
        protected T repository { get; set; }
        protected BaseService(T repo)
        {
            repository = repo;
        }
    }
