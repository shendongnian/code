    public interface IAccountResolver<in TSecurityContext> where TSecurityContext : ISecurityContext
    {
        Account Resolve(TSecurityContext securityContext);
    }
    public class UsernamePasswordAccountResolver : IAccountResolver<UsernamePasswordContext>
    {
        readonly IRepository _repository;
        public UsernamePasswordAccountResolver(IRepository repository)
        {
            _repository = repository;
        }
        public Account Resolve(UsernamePasswordContext securityContext)
        {
            var account = _repository.GetByUsernameAndPassword(securityContext.Username,
                                                               securityContext.Password);
            return account;
        }
    }
    public class SessionAccountResolver : IAccountResolver<SessionContext>
    {
        public Account Resolve(SessionContext securityContext)
        {
            //get the account using the session information
            return someAccount;
        }
    }
