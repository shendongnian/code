    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }
        private ICustomerRepository _customerRepository;
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (this._customerRepository == null)
                {
                    throw new ArgumentException("Missing repository");
                }
                return _customerRepository;
            }
        }
    }
