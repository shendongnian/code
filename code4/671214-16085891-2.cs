    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            unitOfWork.Register(this);
        }
    }
