    //Application Service - consumed by UI
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        public ApplicationService(IAccountRepository accountRepository, ICustomerRepository customerRepository)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }
        public void IssueLumpSumInterestToAccount(Guid accountId)
        {
            using (IUnitOfWork unitOfWork = UnitOfWorkFactory.Create())
            {
                Account account = _accountRepository.GetById(accountId);
                Customer customer = _customerRepository.GetById(account.CustomerId);
                account.IssueLumpSumOfInterest(customer);
                _accountRepository.Save(account);
            }
        }
    }
    public class Customer
    {
        private List<Guid> _accountIds;
        public IEnumerable<Guid> AccountIds
        {
            get { return _accountIds.AsReadOnly();}
        }
    }
    public abstract class Account
    {
        public abstract void IssueLumpSumOfInterest(Customer customer);
    }
    public class FixedAccount : Account
    {
        public override void  IssueLumpSumOfInterest(Customer customer)
        {
 	        if (customer.AccountIds.Any(id => id != this._accountId))
                throw new Exception("Lump Sum cannot be issued to fixed accounts where the customer has other accounts");
            //Code to issue interest here
        }
    }   
    public class SavingsAccount : Account
    {
        public override void  IssueLumpSumOfInterest(Customer customer)
        {
 	        //Code to issue interest here
        }
    }
