    public interface IAuthenticationService
    {
        bool SignIn(string userName, string password, bool rememberMe);
        void SignOut();
    }
    public class WebSecurityAuthenticationService : IAuthenticationService
    {
         public WebSecurityAuthenticationService(IPrincipal user, IUserRepository userRepository)
         {
         }
         ....implementation...
    }
