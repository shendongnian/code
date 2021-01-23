    public class UnitOfWork<E> : IUnitOfWork<E> where E : BaseEntity
    {
        private readonly Repository<E> repository;
    
        public UnitOfWork(Repository<E> repository)
        {
            this.repository = repository;
        }
        //.. other methods
    
    }
