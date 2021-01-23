    public ServiceClass: IService
    {
    
        private readonly IRepositoryFactory _repositoryFactory;
    
        public ServiceClass(IRepositoryFactory factory)
        {
            _repositoryFactory = factory;
        }
        public IList<YourItems> GetYourItems()
        {
            var repository = _repositoryFactory.GetRepositoryOne();
            return repository.GetItems(....);
        }
    }
