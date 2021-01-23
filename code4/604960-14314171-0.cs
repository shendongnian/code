    public class UserFileRepository : IUserRepository
    {
        public UserFileRepository(IUnitOfWork unitOfWork)
        {
            _enquableUow = unitOfWork as IEnquableUnitOfWork;
            if (_enquableUow == null) throw new NotSupportedException("This repository only works with IEnquableUnitOfWork implementations.");
    
        }
    
        public void Add(User user)
        {
            _uow.Append(() => AppendToFile(user));
        }
        public void Uppate(User user)
        {
            _uow.Append(() => ReplaceInFile(user));
        }
    }
