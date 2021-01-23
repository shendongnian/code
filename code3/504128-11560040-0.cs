    public class AccountController
    {
        public AccountController(IAccountsService service)
        {
            _service = service;
        }
        public void SomeActionMethod(Foo someParams)
        {
            _service.SomeAction(someParams);
        }
    }
