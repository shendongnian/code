       public class AccountController : Controller
        {
            private readonly IAccountRepository _accountrepository;
        
            public AccountController(IAccountRepository repository)
            {
                _accountrepository = repository;
            }
    }
