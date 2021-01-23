    public class AccountMembershipProvider : MembershipProvider
    {
        private readonly IAccountRepository _repository;
        public AccountMembershipProvider()
        {
            _repository = ServiceLocator.Current.GetInstance<IAccountRepository>();
            _repository.Initialize();
        }
        public override bool ValidateUser(string username, string password)
        {
            return _repository.IsValidLogin(username, password);
        }
        ...//Other methods
    }
