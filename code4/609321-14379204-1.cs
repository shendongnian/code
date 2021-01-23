    public class UnitOfWork : IUnitOfWork
    {
        private ICustomerRepository _customerRepository;
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (this._customerRepository == null)
                {
                    _customerRepository = ObjectFactory.GetInstance<ICustomerRepository>();
                }
                return _customerRepository;
            }
        }
    }
