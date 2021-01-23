    public class NHibernateRepository : IRepository
    {
    
            public NHibernateRepository(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
    }
