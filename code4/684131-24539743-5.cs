    public class CustomMembershipProvider : MembershipProvider
    {
        private readonly IAccountRepository _repository;
    
        public OpenTibiaMembershipProvider()
        {
            _repository = (IAccountRepository)DependencyResolver.Current.GetService(typeof(IAccountRepository));
        }
        // Rest of implementation.
    }
