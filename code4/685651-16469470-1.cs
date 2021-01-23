    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork;)
        {
            _unitOfWork = unitOfWork;
        }
        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
    }
